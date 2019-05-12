using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public UserController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            SessionSettings.AssignLoginType(LoginType.User);
            _accountService.IsAlive();
            return View("Login");
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new User());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.Get(id);
            return View(ActionType.Edit.ToString(), user);
        }

        [HttpGet]
        public JsonResult Filter(UserFilter filter)
        {
            var response = _userService.Filter(filter);
            return new JsonFactory().Success(response.Users, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(UserFilter filter)
        {
            var response = _userService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "USUARIO,ALIAS,CONCESIONARIO,ROL,ESTADO");
            csv.ConcatRows(0, "Name,UserName,Dealer,Role,Status", response.Users);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Usuarios");
        }

        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            _userService.Login(userLogin);
            return RedirectToAction(ActionType.Index.ToString(), EntityType.Home.ToString());
        }

        [HttpPost]
        public ActionResult Logout()
        {
            _userService.Logout();
            return RedirectToAction(ActionType.Login.ToString(), EntityType.User.ToString());
        }

        [HttpPost]
        public JsonResult ChangePassword(ChangePassword request)
        {
            _userService.ChangePassword(request);
            return new JsonFactory().Success(MessageConstants.ChangePassword);
        }

        [HttpPost]
        public ActionResult Create(User request)
        {
            _userService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.User.ToString());
        }

        [HttpPost]
        public ActionResult Update(User request)
        {
            _userService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.User.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _userService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

    }
}