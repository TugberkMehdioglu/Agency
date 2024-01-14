using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using Project.MVCUI.Areas.Creater.CreatorViewModel;
using Project.MVCUI.Extensions;

namespace Project.MVCUI.Areas.Creater.Controllers
{
    [Area("Creater")]
    [Route("[Area]/[Controller]/[Action]")]
    [Authorize(Roles = "Creator")]
    public class SurveyController : Controller
    {
        private readonly ISurveyManager _surveyManager;
        private readonly IAppUserManager _appUserManager;
        private readonly IGroupManager _groupManager;
        private readonly IQuestionManager _questionManager;
        private readonly IMapper _mapper;

        public SurveyController(ISurveyManager surveyManager, IAppUserManager appUserManager, IGroupManager groupManager, IQuestionManager questionManager, IMapper mapper)
        {
            _surveyManager = surveyManager;
            _appUserManager = appUserManager;
            _groupManager = groupManager;
            _questionManager = questionManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<SurveyViewModel> surveyViewModels = await _surveyManager.GetActives().Select(x => new SurveyViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return View(surveyViewModels);
        }

        [HttpGet("{surveyId}")]
        public async Task<IActionResult> SurveyDetail(int surveyId)
        {
            var (error, survey) = await _surveyManager.GetSurveyWithQuestionAndAnswerById(surveyId);

            if (error != null)
            {
                TempData["fail"] = error;
                return RedirectToAction(nameof(Index));
            }

            SurveyViewModel surveyViewModel = _mapper.Map<SurveyViewModel>(survey);

            return View(surveyViewModel);
        }

        public IActionResult AddSurvey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSurvey(SurveyViewModel request)
        {
            if (!ModelState.IsValid) return View(request);

            int userId = await _appUserManager.Where(x => x.UserName == User.Identity!.Name).Select(x => x.Id).FirstOrDefaultAsync();

            string? error = await _surveyManager.AddAsync(new()
            {
                Name = request.Name,
                CreatedBy = userId
            });

            if(error != null)
            {
                ModelState.AddModelErrorWithOutKey(error);
                return View(request);
            }

            TempData["success"] = "Anket oluşturuldu";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id)
        {
            SurveyViewModel? survey = await _surveyManager.Where(x => x.Id == id && x.Status != DataStatus.Deleted).Select(x => new SurveyViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedBy = x.CreatedBy
            }).FirstOrDefaultAsync();

            if (survey == null)
            {
                TempData["fail"] = "Anket bulunamadı";
                return RedirectToAction(nameof(Index));
            }

            return View(survey);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSurvey(SurveyViewModel request)
        {
            if (!ModelState.IsValid) return View(request);

            string? error = await _surveyManager.UpdateAsync(new()
            {
                Id = request.Id,
                Name = request.Name,
                CreatedBy = request.CreatedBy!.Value
            });

            if(error != null)
            {
                ModelState.AddModelErrorWithOutKey(error);
                return View(request);
            }

            TempData["success"] = "Anket güncellendi";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            Survey? survey = await _surveyManager.FindAsync(id);
            if(survey == null)
            {
                TempData["fail"] = "Anket bulunamadı";
                return RedirectToAction(nameof(Index));
            }

            string? error = await _surveyManager.DeleteAsync(survey);
            if(error != null)
            {
                TempData["fail"] = error;
                return RedirectToAction(nameof(Index));
            }

            TempData["success"] = "Anket silindi";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{surveyId}")]
        public async Task<IActionResult> AddQuestionToSurvey(int surveyId)
        {
            List<GroupViewModel> groupViewModels = await _groupManager.GetActives().Select(x => new GroupViewModel()
            {
                Id = x.Id,
                Code = x.Code,
                Score = x.Score
            }).ToListAsync();

            TempData["groupSelectList"] = new SelectList(groupViewModels, nameof(GroupViewModel.Id), nameof(GroupViewModel.Code));

            QuestionViewModel questionViewModel = new QuestionViewModel() { SurveyId = surveyId };

            return View(model: questionViewModel);
        }

        [HttpPost("{surveyId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddQuestionToSurvey(QuestionViewModel request)
        {
            Question question = _mapper.Map<Question>(request);
            question.ChildQuestions = null;

            string? result = await _questionManager.AddAsync(question);
            if (result != null)
            {
                TempData["fail"] = result;
                return RedirectToAction(nameof(Index));
            }

            if(request.ChildQuestions != null && request.ChildQuestions.Count > 0)
            {
                question.ChildQuestions = _mapper.Map<List<Question>>(request.ChildQuestions);

                string? result2 = await _questionManager.AddRangeAsync(question.ChildQuestions);
                if (result2 != null)
                {
                    TempData["fail"] = result2;
                    return RedirectToAction(nameof(Index));
                }
            }          

            TempData["success"] = "Anket sorusu eklendi";
            return RedirectToAction(nameof(Index));
        }
    }
}
