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
    public class DealerController : Controller
    {
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Dealer());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dealer = _dealerService.Get(id);
            return View(ActionType.Edit.ToString(), dealer);
        }

        [HttpGet]
        public JsonResult Filter(DealerFilter filter)
        {
            var response = _dealerService.Filter(filter);
            return new JsonFactory().Success(response.Dealers, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(DealerFilter filter)
        {
            var response = _dealerService.Filter(filter);
            var csv = new CsvExport();
            csv.ConcatRow(0, "CONCESIONARIO,ESTADO");
            csv.ConcatRows(0, "Name,Status", response.Dealers);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Concesionarios");
        }

        [HttpPost]
        public ActionResult Create(Dealer request)
        {
            _dealerService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Dealer.ToString());
        }

        [HttpPost]
        public ActionResult Update(Dealer request)
        {
            _dealerService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Dealer.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _dealerService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _dealerService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}