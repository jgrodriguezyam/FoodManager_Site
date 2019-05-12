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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Company());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company = _companyService.Get(id);
            return View(ActionType.Edit.ToString(), company);
        }

        [HttpGet]
        public JsonResult Filter(CompanyFilter filter)
        {
            var response = _companyService.Filter(filter);
            return new JsonFactory().Success(response.Companies, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(CompanyFilter filter)
        {
            var response = _companyService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "COMPAÑÍA,ESTADO");
            csv.ConcatRows(0, "Name,Status", response.Companies);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Compañías");
        }

        [HttpPost]
        public ActionResult Create(Company request)
        {
            _companyService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Company.ToString());
        }

        [HttpPost]
        public ActionResult Update(Company request)
        {
            _companyService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Company.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _companyService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _companyService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}