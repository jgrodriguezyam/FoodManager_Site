using System.Web.Mvc;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            _accountService.IsAlive();
            return View("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult ChangePassword()
        {
            return View("ChangePassword", new User());
        }

        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult _Logout()
        {
            return PartialView("_Logout");
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ChangeLoginType(LoginType loginType)
        {
            SessionSettings.AssignLoginType(loginType);
            return new JsonFactory().Success(true);
        }
    }
}