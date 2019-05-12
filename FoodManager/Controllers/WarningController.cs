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
    public class WarningController : Controller
    {
        private readonly IWarningService _warningService;

        public WarningController(IWarningService warningService)
        {
            _warningService = warningService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Warning());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
                var warning = _warningService.Get(id);
                return View(ActionType.Edit.ToString(), warning);
        }

        [HttpGet]
        public JsonResult Filter(WarningFilter filter)
        {
            var response = _warningService.Filter(filter);
            return new JsonFactory().Success(response.Warnings, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(WarningFilter filter)
        {
            var response = _warningService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "CÓDIGO,ADVERTENCIA,ENFERMEDAD,ESTADO");
            csv.ConcatRows(0, "Code,Name,Disease,Status", response.Warnings);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Advertencias");
        }

        [HttpPost]
        public ActionResult Create(Warning request)
        {
            _warningService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Warning.ToString());
        }

        [HttpPost]
        public ActionResult Update(Warning request)
        {
            _warningService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Warning.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _warningService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _warningService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}