using System.Linq;
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
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IDealerService _dealerService;

        public BranchController(IBranchService branchService, IDealerService dealerService)
        {
            _branchService = branchService;
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
            return View(ActionType.New.ToString(), new Branch());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var branch = _branchService.Get(id);
            branch.Dealers = _dealerService.OnlyWithBranchId(id);
            return View(ActionType.Edit.ToString(), branch);
        }

        [HttpGet]
        public JsonResult Filter(BranchFilter filter)
        {
            var response = _branchService.Filter(filter);
            return new JsonFactory().Success(response.Branches, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(BranchFilter filter)
        {
            var response = _branchService.Filter(filter);
            foreach (var branch in response.Branches)
            {
                branch.Dealers = _dealerService.OnlyWithBranchId(branch.Id);
            }

            var csv = new CsvExport();
            csv.ConcatRow(0, "CÓDIGO,SUCURSAL,REGIÓN,COMPAÑÍA,CONCESIONARIOS,ESTADO");
            csv.ConcatRows(0, "Code,Name,Region,Company,Dealers,Status", response.Branches);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Sucursales");
        }

        [HttpPost]
        public ActionResult Create(Branch request)
        {
            _branchService.Create(request);
            _branchService.AssignDealers(request.Id, request.DealerIds);
            return RedirectToAction(Request.Form["View"], EntityType.Branch.ToString());
        }

        [HttpPost]
        public ActionResult Update(Branch request)
        {
            _branchService.Update(request);

            if (request.Status)
            {
                var dealersInDataBase = _dealerService.OnlyWithBranchId(request.Id);
                var dealerIdsInDataBase = dealersInDataBase.Select(x => x.Id).ToList();
                var dealerIdsByAssign = request.DealerIds.Except(dealerIdsInDataBase);
                var dealerIdsByUnassign = dealerIdsInDataBase.Except(request.DealerIds);

                _branchService.AssignDealers(request.Id, dealerIdsByAssign);
                _branchService.RemoveDealers(request.Id, dealerIdsByUnassign);
            }

            return RedirectToAction(Request.Form["View"], EntityType.Branch.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _branchService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _branchService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}