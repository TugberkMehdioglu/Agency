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

        public SurveyController(ISurveyManager surveyManager, IMapper mapper, IAppUserSurveyManager appUserSurveyManager, IAppUserAnswerManager appUserAnswerManager, IAppUserManager appUserManager)
        {
            _surveyManager = surveyManager;
            _mapper = mapper;
            _appUserSurveyManager = appUserSurveyManager;
            _appUserAnswerManager = appUserAnswerManager;
            _appUserManager = appUserManager;
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
        public IActionResult SolveSurveyAgain(int surveyId)
        {


            return View();
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
    }
}
