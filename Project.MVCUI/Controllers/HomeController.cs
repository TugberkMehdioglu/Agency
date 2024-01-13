using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.MVCUI.Extensions;
using Project.MVCUI.ViewModels;
using System.Diagnostics;

namespace Project.MVCUI.Controllers
{
    [Route("[Controller]/[Action]")]
    public class HomeController : Controller
    {
        private readonly IAppUserManager _appUserManager;

        public HomeController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [Route("/")]
        [Route("/Home")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel request, string? returnUrl)
        {
            if (!ModelState.IsValid) return View(request);

            returnUrl ??= "/Home";

            var (error, appUser) = await _appUserManager.FindByEmailViaIdentity(request.Email);

            if(error != null)
            {
                ModelState.AddModelErrorWithOutKey(error);
                return View(request);
            }

            string? result = await _appUserManager.PasswordSignInAsync(appUser!, request.Password, request.RememberMe, true);

            if (result != null)
            {
                ModelState.AddModelErrorWithOutKey(result);
                return View(request);
            }

            return Redirect(returnUrl);
        }

        public async Task Logout()
        {
            await _appUserManager.SignOutAsync();
        }
    }
}