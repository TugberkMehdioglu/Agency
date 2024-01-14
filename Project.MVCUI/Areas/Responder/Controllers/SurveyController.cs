using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.ManagerServices.Abstracts;
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

        public SurveyController(ISurveyManager surveyManager, IMapper mapper)
        {
            _surveyManager = surveyManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Survey> surveys = await _surveyManager.GetActives().ToListAsync();

            List<SurveyViewModel> surveyViewModels = _mapper.Map<List<SurveyViewModel>>(surveys);

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
    }
}
