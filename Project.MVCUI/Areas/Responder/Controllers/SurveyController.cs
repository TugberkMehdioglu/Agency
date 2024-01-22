using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Creater.CreatorViewModel;

namespace Project.MVCUI.Areas.Responder.Controllers
{
    [Area("Responder")]
    [Route("[Area]/[Controller]/[Action]")]
    [Authorize(Roles = "Responder")]
    public class SurveyController : Controller
    {
        private readonly ISurveyManager _surveyManager;
        private readonly IMapper _mapper;
        private readonly IAppUserSurveyManager _appUserSurveyManager;
        private readonly IAppUserAnswerManager _appUserAnswerManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IQuestionManager _questionManager;

        public SurveyController(ISurveyManager surveyManager, IMapper mapper, IAppUserSurveyManager appUserSurveyManager, IAppUserAnswerManager appUserAnswerManager, IAppUserManager appUserManager, IQuestionManager questionManager)
        {
            _surveyManager = surveyManager;
            _mapper = mapper;
            _appUserSurveyManager = appUserSurveyManager;
            _appUserAnswerManager = appUserAnswerManager;
            _appUserManager = appUserManager;
            _questionManager = questionManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Survey> surveys = await _surveyManager.GetActives().ToListAsync();

            List<SurveyViewModel> surveyViewModels = _mapper.Map<List<SurveyViewModel>>(surveys);

            var (error, appUser) = await _appUserManager.FindByNameViaIdentity(User.Identity!.Name!);

            foreach (SurveyViewModel item in surveyViewModels)
            {
                if (await _appUserSurveyManager.AnyAsync(x => x.SurveyId == item.Id && x.AppUserId == appUser!.Id))
                {
                    item.IsCompleted = true;
                }
            }

            return View(surveyViewModels);
        }

        [HttpGet("{surveyId}")]
        public async Task<IActionResult> SolveSurvey(int surveyId)
        {
            var (error, survey) = await _surveyManager.GetSurveyWithQuestionAndAnswerById(surveyId);
            if(error != null)
            {
                TempData["fail"] = error;
                return RedirectToAction(nameof(Index));
            }

            SurveyViewModel surveyViewModel = _mapper.Map<SurveyViewModel>(survey);

            return View(surveyViewModel);
        }

        [HttpGet("{surveyId}")]
        public async Task<IActionResult> SolveSurveyAgain(int surveyId)
        {
            var (error, survey) = await _surveyManager.GetSurveyWithQuestionAndAnswerById(surveyId);
            if(error != null)
            {
                TempData["fail"] = error;
                return RedirectToAction(nameof(Index));
            }

            var (appUserError, appUser) = await _appUserManager.FindByNameViaIdentity(User.Identity!.Name!);
            if(appUserError != null)
            {
                TempData["fail"] = error;
                return RedirectToAction(nameof(Index));
            }

            SurveyViewModel surveyViewModel = _mapper.Map<SurveyViewModel>(survey);

            int? FormerAnswerId = null;

            foreach (QuestionViewModel item in surveyViewModel.Questions.Where(x => x.ParentQuestionId == null)!)
            {
                foreach (AnswerViewModel element in item.Answers!)
                {
                    if (await _appUserAnswerManager.AnyAsync(x => x.AppUserId == appUser!.Id && x.AnswerId == element.Id && x.Status != DataStatus.Deleted))
                    {
                        FormerAnswerId = element.Id;
                        break;
                    }
                }

                if(FormerAnswerId != null)
                {
                    foreach (AnswerViewModel element2 in item.Answers!)
                    {
                        if (element2.FormerAnswerId == null) element2.FormerAnswerId = FormerAnswerId;
                    }
                }

                FormerAnswerId = null;

                if(item.ChildQuestions.Count > 0)
                {
                    foreach (QuestionViewModel childQuestion in item.ChildQuestions)
                    {
                        foreach (AnswerViewModel childAnswer in childQuestion.Answers)
                        {
                            if (await _appUserAnswerManager.AnyAsync(x => x.AppUserId == appUser!.Id && x.AnswerId == childAnswer.Id && x.Status != DataStatus.Deleted))
                            {
                                FormerAnswerId = childAnswer.Id;
                                break;
                            }
                        }

                        if (FormerAnswerId != null)
                        {
                            foreach (AnswerViewModel childAnswer in childQuestion.Answers)
                            {
                                if (childAnswer.FormerAnswerId == null) childAnswer.FormerAnswerId = FormerAnswerId;
                            }
                        }

                        FormerAnswerId = null;
                    }
                }
            }

            return View(surveyViewModel);
        }


        public async Task<IActionResult> EditSurvey(int? FormerAnswerId, int AnswerId, int SurveyId)
        {
            AppUser? appUser = await _appUserManager.Where(x => x.UserName == User.Identity!.Name && x.Status != DataStatus.Deleted).FirstOrDefaultAsync();
            if (appUser == null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcı bulunamadı" });

            if(FormerAnswerId == AnswerId)
            {
                return Ok(new { message = "Tammamdır babba" });
            }
            else if (FormerAnswerId.HasValue && (await _appUserAnswerManager.AnyAsync(x => x.AnswerId == AnswerId && x.AppUserId == appUser.Id && x.Status == DataStatus.Deleted)))
            {
                AppUserAnswer appUserAnswer = (await _appUserAnswerManager.Where(x => x.AnswerId == AnswerId && x.AppUserId == appUser.Id && x.Status == DataStatus.Deleted).FirstOrDefaultAsync())!;
                appUserAnswer.ModifiedDate = DateTime.Now;
                appUserAnswer.DeletedDate = null;
                appUserAnswer.Status = DataStatus.Updated;

                AppUserAnswer formerAppUserAnswer = (await _appUserAnswerManager.Where(x => x.AnswerId == FormerAnswerId && x.AppUserId == appUser.Id).FirstOrDefaultAsync())!;

                await _appUserAnswerManager.DeleteAsync(formerAppUserAnswer);
                await _appUserAnswerManager.UpdateAsync(appUserAnswer);//Status'u delete'den update'e çektik.
            }
            else if (FormerAnswerId.HasValue)
            {
                AppUserAnswer formerAppUserAnswer = (await _appUserAnswerManager.Where(x => x.AnswerId == FormerAnswerId && x.AppUserId == appUser.Id).FirstOrDefaultAsync())!;

                string? error = await _appUserAnswerManager.DeleteAsync(formerAppUserAnswer);
                if (error != null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = error });

                AppUserAnswer newAppUserAnswer = new() { AppUserId = appUser.Id, AnswerId = AnswerId };

                string? newError = await _appUserAnswerManager.AddAsync(newAppUserAnswer);
                if (newError != null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = newError });

            }
            else
            {
                AppUserAnswer appUserAnswer = new() { AppUserId = appUser.Id, AnswerId = AnswerId };

                string? error = await _appUserAnswerManager.AddAsync(appUserAnswer);
                if (error != null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = error });
            }

            return Ok(new { message = "Tammamdır babba" });
        }


        [HttpPost]
        public async Task<IActionResult> QuestionAnswer(int QuestionId, int AnswerId, int SurveyId)
        {
            AppUser? appUser = await _appUserManager.Where(x => x.UserName == User.Identity!.Name && x.Status != DataStatus.Deleted).FirstOrDefaultAsync();
            if (appUser == null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcı bulunamadı" });

            if (!(await _appUserSurveyManager.AnyAsync(x => x.AppUserId == appUser!.Id && x.SurveyId == SurveyId)))
            {
                Survey? survey = await _surveyManager.FindAsync(SurveyId);
                if (survey == null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Anket bulunamadı" });

                AppUserSurvey appUserSurvey = new() { AppUserId = appUser!.Id, SurveyId = survey.Id };

                string? surveyResult = await _appUserSurveyManager.AddAsync(appUserSurvey);
                if (surveyResult != null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = surveyResult });
            }

            if (!(await _appUserAnswerManager.AnyAsync(x => x.AnswerId == AnswerId && x.AppUserId == appUser!.Id)))
            {
                AppUserAnswer appUserAnswer = new() { AnswerId = AnswerId, AppUserId = appUser!.Id };

                string? answerResult = await _appUserAnswerManager.AddAsync(appUserAnswer);
                if (answerResult != null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = answerResult });
            }


            return Ok(new { message = "Tammamdır babba" });
        }

        
        public async Task<IActionResult> CalculateSurvey(int surveyId)
        {
            List<Question> questions = await _questionManager.GetQuestionsAndAnswersWithGroupBySurveyIdAsync(surveyId).Result.ToListAsync();

            int score = 0;

            var (error, appUser) = await _appUserManager.FindByNameViaIdentity(User.Identity!.Name!);

            foreach (Question item in questions)
            {
                foreach (Answer element in item.Answers)
                {
                    if (await _appUserAnswerManager.AnyAsync(x => x.AnswerId == element.Id && x.AppUserId == appUser!.Id && x.Status != DataStatus.Deleted))
                    {
                        score += item.Group.Score;
                    }
                }               
            }

            if(score > 0)
            {                
                AppUserSurvey? appUserSurvey = await _appUserSurveyManager.Where(x => x.AppUserId == appUser!.Id && x.SurveyId == surveyId && x.Status != DataStatus.Deleted).FirstOrDefaultAsync();
                if (appUserSurvey == null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcıya bağlı anket bulunamadı" });

                appUserSurvey.Score = score;

                string? surveyError = await _appUserSurveyManager.UpdateAsync(appUserSurvey);
                if (surveyError != null) return StatusCode(StatusCodes.Status500InternalServerError, new { message = surveyError });
            }

            return Ok(new { message = "Tammamdır babba" });
        }
    }
}
