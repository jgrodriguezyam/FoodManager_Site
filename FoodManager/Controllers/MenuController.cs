using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Menu());
        }

        [HttpGet]
        public ViewResult NewWithTemplate(int id)
        {
            var menu = _menuService.Get(id);
            menu.Id = 0;
            menu.Saucer = new Saucer();
            menu.MaxAmount = 0;
            menu.Comment = "";
            return View(ActionType.New.ToString(), menu);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menu = _menuService.Get(id);
            return View(ActionType.Edit.ToString(), menu);
        }

        [HttpGet]
        public JsonResult Filter(MenuFilter filter)
        {
            var response = _menuService.Filter(filter);
            return new JsonFactory().Success(response.Menus, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(MenuFilter filter)
        {
            var response = _menuService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "TIPO,DÍA,FECHA INICIO,FECHA FIN,PLATILLO,CONCESIONARIO,COMENTARIO,ESTADO");
            csv.ConcatRows(0, "MealTypeLabel,DayWeekLabel,StartDate,EndDate,Saucer,Dealer,Comment,Status", response.Menus);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Menús");
        }

        [HttpPost]
        public ActionResult Create(Menu request)
        {
            _menuService.Create(request);
            if (Request.Form["View"].IsEquals(ActionType.New.ToString()))
            {
                return RedirectToAction(ActionType.NewWithTemplate.ToString(), EntityType.Menu.ToString(), new {id = request.Id});
            }
            return RedirectToAction(Request.Form["View"], EntityType.Menu.ToString());
        }

        [HttpPost]
        public ActionResult Update(Menu request)
        {
            _menuService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Menu.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _menuService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _menuService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }
    }
}