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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Department());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var response = _departmentService.Get(id);
            return View(ActionType.Edit.ToString(), response);
        }

        [HttpGet]
        public JsonResult Filter(DepartmentFilter filter)
        {
            var response = _departmentService.Filter(filter);
            return new JsonFactory().Success(response.Departments, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(DepartmentFilter filter)
        {
            var response = _departmentService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "DEPARTAMENTO,ESTADO");
            csv.ConcatRows(0, "Name,Status", response.Departments);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Departamentos");
        }

        [HttpPost]
        public ActionResult Create(Department request)
        {
            _departmentService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Department.ToString());
        }

        [HttpPost]
        public ActionResult Update(Department request)
        {
            _departmentService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Department.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _departmentService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _departmentService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}