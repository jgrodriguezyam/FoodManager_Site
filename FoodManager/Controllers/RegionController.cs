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
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Region());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var response = _regionService.Get(id);
            return View(ActionType.Edit.ToString(), response);
        }

        [HttpGet]
        public JsonResult Filter(RegionFilter filter)
        {
            var response = _regionService.Filter(filter);
            return new JsonFactory().Success(response.Regions, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(RegionFilter filter)
        {
            var response = _regionService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "REGIÓN,ESTADO");
            csv.ConcatRows(0, "Name,Status", response.Regions);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Regiones");
        }

        [HttpPost]
        public ActionResult Create(Region request)
        {
                _regionService.Create(request);
                return RedirectToAction(Request.Form["View"], EntityType.Region.ToString());
        }

        [HttpPost]
        public ActionResult Update(Region request)
        {
            _regionService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Region.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _regionService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _regionService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}