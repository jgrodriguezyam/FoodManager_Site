using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Resolvers;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Reports;
using FoodManager.Services.Interfaces;
using Worker = FoodManager.Models.Worker;

namespace FoodManager.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        private readonly IAccountService _accountService;
        private readonly IReservationService _reservationService;
        private readonly IBranchService _branchService;

        public WorkerController(IWorkerService workerService, IAccountService accountService, IReservationService reservationService, IBranchService branchService)
        {
            _workerService = workerService;
            _accountService = accountService;
            _reservationService = reservationService;
            _branchService = branchService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            SessionSettings.AssignLoginType(LoginType.Worker);
            _accountService.IsAlive();
            return View("Login");
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Worker());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var worker = _workerService.Get(id);
            return View(ActionType.Edit.ToString(), worker);
        }

        [HttpGet]
        public ActionResult Report()
        {
            new TempDataFactory().CreateInformation(this, MessageConstants.WorkerReportInformation);
            var reportResponse = _workerService.Report(new WorkerReport());
            return View(reportResponse);
        }

        [HttpGet]
        public JsonResult Filter(WorkerFilter filter)
        {
            var response = _workerService.Filter(filter);
            if (filter.IsReport)
            {
                var branches = _branchService.Filter(new BranchFilter()).Branches;
                response.Workers.ForEach(worker =>  worker.Branch = branches.FirstOrDefault(branch => branch.Id.IsEqualTo(worker.BranchId)));
            }
            return new JsonFactory().Success(response.Workers, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(WorkerFilter filter)
        {
            var response = _workerService.Filter(filter);
            var branches = _branchService.Filter(new BranchFilter()).Branches;

            var csv = new CsvExport();
            if (filter.IsReport)
            {
                csv.ConcatRow(0, "COMPAÑÍA,ID SUCURSAL,SUCURSAL,DEPARTAMENTO,PUESTO,CÓDIGO,NOMBRE,GÉNERO,NSS,FECHA CONSUMO,CONSUMIDO,RECOMENDADO");
                foreach (var worker in response.Workers)
                {
                    var today = DateTimeExtensions.Today();
                    var startDate = filter.Month.IsGreaterThanZero() ? new DateTime(today.Year, today.Month, 1).ConvertToString() : "" ;
                    var endDate = filter.Month.IsGreaterThanZero() ? new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)).ConvertToString() : ""; ;
                    var responseCalories = _reservationService.Report(new ReservationReport { WorkerId = worker.Id, StartDate = startDate, EndDate = endDate});
                    var currentCompany = branches.First(branch => branch.Id.IsEqualTo(worker.BranchId)).Company.Name;
                    //var responseCalories = new ReservationReportResponse
                    //{
                    //    Calories = new List<ReservationCalorieReportResponse>
                    //{
                    //    new ReservationCalorieReportResponse{Date = DateTimeExtensions.Today().AddDays(-7).ConvertToString(),Dinner = 200, Lunch = 1000, BreakFast = 150},
                    //    new ReservationCalorieReportResponse{Date = DateTimeExtensions.Today().AddDays(-6).ConvertToString(),Dinner = 164, Lunch = 1000, BreakFast = 150},
                    //    new ReservationCalorieReportResponse{Date = DateTimeExtensions.Today().AddDays(-5).ConvertToString(),Dinner = 195, Lunch = 1000, BreakFast = 150},
                    //    new ReservationCalorieReportResponse{Date = DateTimeExtensions.Today().AddDays(-4).ConvertToString(),Dinner = 109, Lunch = 1000, BreakFast = 203},
                    //    new ReservationCalorieReportResponse{Date = DateTimeExtensions.Today().AddDays(-3).ConvertToString(),Dinner = 287, Lunch = 1000, BreakFast = 343},
                    //    new ReservationCalorieReportResponse{Date = DateTimeExtensions.Today().AddDays(-2).ConvertToString(),Dinner = 207, Lunch = 1000, BreakFast = 150},
                    //    new ReservationCalorieReportResponse{Date = DateTimeExtensions.Today().AddDays(-1).ConvertToString(),Dinner = 218, Lunch = 1000, BreakFast = 145}
                    //}
                    //};
                    foreach (var calorie in responseCalories.Calories)
                    {
                        var sumCalories = calorie.BreakFast + calorie.Dinner + calorie.Lunch;
                        var row = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", currentCompany, worker.BranchId, worker.Branch.Name, worker.Department.Name, worker.Job.Name, worker.Code, worker.FullName, EnumResolver.Gender(worker.Gender.GetValue()), worker.Imss, calorie.Date, sumCalories.RoundDecimal(), worker.LimitEnergy);
                        csv.ConcatRow(0, row);
                    }
                }
            }
            else
            {
                csv.ConcatRow(0, "CÓDIGO,NOMBRE,APELLIDO,EMAIL,IMSS,GÉNERO,GAFFETE,INGESTA CALÓRICA,SUCURSAL,DEPARTAMENTO,PUESTO,ROL,ESTADO");
                csv.ConcatRows(0, "Code,FirstName,LastName,Email,Imss,GenderLabel,Badge,LimitEnergy,Branch,Department,Job,Role,Status", response.Workers);
            }

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Ingesta calórica por colaborador");
        }

        [HttpPost]
        public ActionResult Login(WorkerLogin workerLogin)
        {
            _workerService.Login(workerLogin);
            var actionType = workerLogin.WithoutFilters ? ActionType.IndexWithoutFilters : ActionType.Index;
            return RedirectToAction(actionType.ToString(), EntityType.Reservation.ToString());
        }

        [HttpPost]
        public ActionResult ExternalLogin(string gafete)
        {
            var workerLogin = new WorkerLogin {Badge = gafete };
            _workerService.Login(workerLogin);
            return RedirectToAction(ActionType.Index.ToString(), EntityType.Reservation.ToString());
        }

        [HttpPost]
        public ActionResult Logout()
        {
            _workerService.Logout();
            return RedirectToAction(ActionType.Login.ToString(), EntityType.Worker.ToString());
        }

        [HttpPost]
        public ActionResult Create(Worker request)
        {
            _workerService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Worker.ToString());
        }

        [HttpPost]
        public ActionResult Update(Worker request)
        {
            _workerService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Worker.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _workerService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

    }
}