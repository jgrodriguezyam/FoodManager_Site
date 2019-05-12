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
    public class JobController : Controller
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Job());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var response = _jobService.Get(id);
            return View(ActionType.Edit.ToString(), response);
        }

        [HttpGet]
        public JsonResult Filter(JobFilter filter)
        {
            var response = _jobService.Filter(filter);
            return new JsonFactory().Success(response.Jobs, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(JobFilter filter)
        {
                var response = _jobService.Filter(filter);

                var csv = new CsvExport();
                csv.ConcatRow(0, "PUESTO,ESTADO");
                csv.ConcatRows(0, "Name,Status", response.Jobs);

                var stream = csv.RetrieveFile();
                return new StreamFactory().Csv(stream, "Puestos");
        }

        [HttpPost]
        public ActionResult Create(Job request)
        {
            _jobService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Job.ToString());
        }

        [HttpPost]
        public ActionResult Update(Job request)
        {
            _jobService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Job.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _jobService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _jobService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}