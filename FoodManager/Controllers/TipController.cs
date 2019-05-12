using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class TipController : Controller
    {
        private readonly ITipService _tipService;

        public TipController(ITipService tipService)
        {
            _tipService = tipService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Tip());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var response = _tipService.Get(id);
            return View(ActionType.Edit.ToString(), response);
        }

        [HttpGet]
        public JsonResult Filter(TipFilter filter)
        {
            var response = _tipService.Filter(filter);
            return new JsonFactory().Success(response.Tips, response.TotalRecords);
        }

        [HttpGet]
        public JsonResult GetRandom()
        {
            var response = _tipService.Filter(new TipFilter {StartPage = 1, EndPage = 1, OnlyStatusActivated = true});
            var randomId = new RandomFactory().Number(response.TotalRecords);
            var tip = _tipService.Get(randomId);
            return new JsonFactory().Success(tip);
        }

        [HttpGet]
        public FileResult Export(TipFilter filter)
        {
            var response = _tipService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "CONSEJO,ESTADO");
            csv.ConcatRows(0, "Name,Status", response.Tips);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Consejos");
        }

        [HttpPost]
        public ActionResult Create(Tip request)
        {
            _tipService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Tip.ToString());
        }

        [HttpPost]
        public ActionResult Update(Tip request)
        {
            _tipService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Tip.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _tipService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _tipService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}