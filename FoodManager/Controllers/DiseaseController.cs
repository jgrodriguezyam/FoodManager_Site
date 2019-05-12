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
    public class DiseaseController : Controller
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Disease());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var response = _diseaseService.Get(id);
            return View(ActionType.Edit.ToString(), response);
        }

        [HttpGet]
        public JsonResult Filter(DiseaseFilter filter)
        {
            var response = _diseaseService.Filter(filter);
            return new JsonFactory().Success(response.Diseases, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(DiseaseFilter filter)
        {
            var response = _diseaseService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "CÓDIGO,ENFERMEDAD,ESTADO");
            csv.ConcatRows(0, "Code,Name,Status", response.Diseases);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Enfermedades");
        }

        [HttpPost]
        public ActionResult Create(Disease request)
        {
            _diseaseService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Disease.ToString());
        }

        [HttpPost]
        public ActionResult Update(Disease request)
        {
            _diseaseService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Disease.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _diseaseService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _diseaseService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}