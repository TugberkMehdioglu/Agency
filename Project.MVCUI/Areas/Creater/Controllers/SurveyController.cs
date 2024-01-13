using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.MVCUI.Areas.Creater.Controllers
{
    [Area("Creater")]
    [Route("[Area]/[Controller]/[Action]")]
    [Authorize(Roles = "Creater")]
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
