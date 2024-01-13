using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize(Roles = "Creater")]
    public class SurveyController : Controller
    {
        private readonly ISurveyManager _surveyManager;
        private readonly IAppUserManager _appUserManager;

        public SurveyController(ISurveyManager surveyManager, IAppUserManager appUserManager)
        {
            _surveyManager = surveyManager;
            _appUserManager = appUserManager;
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
    }
}
