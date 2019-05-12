using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Models.Reports;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class ReservationController : Controller
    {

        private readonly IReservationService _reservationService;
        private readonly ISaucerService _saucerService;
        private readonly IMenuService _menuService;
        private readonly ISaucerConfigurationService _saucerConfigurationService;
        private readonly ISaucerMultimediaService _saucerMultimediaService;

        public ReservationController(IReservationService reservationService, ISaucerService saucerService, IMenuService menuService, ISaucerConfigurationService saucerConfigurationService, ISaucerMultimediaService saucerMultimediaService)
        {
            _reservationService = reservationService;
            _saucerService = saucerService;
            _menuService = menuService;
            _saucerConfigurationService = saucerConfigurationService;
            _saucerMultimediaService = saucerMultimediaService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ActionResult IndexWithoutFilters()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public JsonResult Filter(ReservationFilter filter)
        {
            var response = _reservationService.Filter(filter);
            return new JsonFactory().Success(response.Reservations, response.TotalRecords);
        }

        [HttpGet]
        public JsonResult MenusOrSaucers(int? dealerId, string date)
        {
            List<int> saucerIds;
            SaucerConfigurationPage saucerConfigurationPage;
            SaucerMultimediaPage saucerMultimediaPage;
            if (dealerId.GetValue().IsGreaterThanZero())
            {
                var menuResponse = _menuService.Filter(new MenuFilter { DealerId = dealerId.GetValue(), Date = date, OnlyStatusActivated = true, Sort = "ASC", SortBy = "Name" });
                saucerIds = menuResponse.Menus.Select(x => x.SaucerId).ToList();
                saucerConfigurationPage = _saucerConfigurationService.Filter(new SaucerConfigurationFilter { OnlyStatusActivated = true, SaucerIds = string.Join(",", saucerIds) });
                saucerMultimediaPage = _saucerMultimediaService.Filter(new SaucerMultimediaFilter { OnlyStatusActivated = true, SaucerIds = string.Join(",", saucerIds) });
                foreach (var menu in menuResponse.Menus)
                {
                    menu.Saucer.SaucerMultimedias = saucerMultimediaPage.SaucerMultimedias.Where(x => x.SaucerId.IsEqualTo(menu.SaucerId)).ToList();
                    menu.Saucer.SaucerConfigurations = saucerConfigurationPage.SaucerConfigurations.Where(x => x.SaucerId.IsEqualTo(menu.SaucerId)).ToList();
                }
                return new JsonFactory().Success(menuResponse.Menus, menuResponse.TotalRecords);
            }
            
            var saucerResponse = _saucerService.Filter(new SaucerFilter { OnlyStatusActivated = true, Sort = "ASC", SortBy = "Name"});
            saucerIds = saucerResponse.Saucers.Select(x => x.Id).ToList();
            saucerConfigurationPage = _saucerConfigurationService.Filter(new SaucerConfigurationFilter { OnlyStatusActivated = true, SaucerIds = string.Join(",", saucerIds) });
            saucerMultimediaPage = _saucerMultimediaService.Filter(new SaucerMultimediaFilter { OnlyStatusActivated = true, SaucerIds = string.Join(",", saucerIds) });
            foreach (var saucer in saucerResponse.Saucers)
            {
                saucer.SaucerMultimedias = saucerMultimediaPage.SaucerMultimedias.Where(x => x.SaucerId.IsEqualTo(saucer.Id)).ToList();
                saucer.SaucerConfigurations = saucerConfigurationPage.SaucerConfigurations.Where(x => x.SaucerId.IsEqualTo(saucer.Id)).ToList();
            }
            return new JsonFactory().Success(saucerResponse.Saucers, saucerResponse.TotalRecords);
        }

        [HttpGet]
        public ActionResult Report(ReservationReport request)
        {
            request.StartDate = DateTime.Now.AddMonths(-1).ConvertToString();
            request.EndDate = DateTime.Now.ConvertToString();
            request.WorkerId = SessionSettings.RetrieveWorkerId;
            TempData["StartDate"] = request.StartDate;
            TempData["EndDate"] = request.EndDate;
            var reportResponse = _reservationService.Report(request);
            foreach(var a in reportResponse.Calories)
            {
                a.BreakFast = a.BreakFast.RoundDecimal();
                a.Dinner = a.Dinner.RoundDecimal();
                a.Lunch = a.Lunch.RoundDecimal();
            }
            return View(reportResponse);
        }

        [HttpPost]
        public JsonResult Save(List<Reservation> reservations, string date, int? dealerId)
        {
            try
            {
                var reservationsInDataBase = _reservationService.Filter(new ReservationFilter { Date = date, DealerId = dealerId.GetValue(), WithoutDealer = dealerId.GetValue().IsEqualToZero() }).Reservations;
                var reservationsByCreate = new List<Reservation>();
                var reservationsByUpdate = new List<Reservation>();
                var reservationsByDelete = new List<Reservation>();

                if (reservations.IsNotEmpty() && reservationsInDataBase.IsNotEmpty())
                {
                    reservationsByCreate.AddRange(reservations.Where(x => !reservationsInDataBase.Any(y => y.SaucerId == x.SaucerId && y.MealType == x.MealType)));
                    reservationsByUpdate.AddRange(reservations.Where(x => reservationsInDataBase.Any(y => y.SaucerId == x.SaucerId && y.MealType == x.MealType)));
                    reservationsByDelete.AddRange(reservationsInDataBase.Where(x => !reservations.Any(y => y.SaucerId == x.SaucerId && y.MealType == x.MealType)));
                }

                if (reservations.IsNotEmpty() && reservationsInDataBase.IsEmpty())
                {
                    reservationsByCreate.AddRange(reservations);
                }

                if (reservations.IsEmpty() && reservationsInDataBase.IsNotEmpty())
                {
                    reservationsByDelete.AddRange(reservationsInDataBase);
                }

                foreach (var reservationByCreate in reservationsByCreate)
                    _reservationService.Create(reservationByCreate);

                foreach (var reservationByUpdate in reservationsByUpdate)
                {
                    reservationByUpdate.Id = reservationsInDataBase.First(x => x.SaucerId.IsEqualTo(reservationByUpdate.SaucerId) && x.MealType.IsEquals(reservationByUpdate.MealType)).Id;
                    _reservationService.Update(reservationByUpdate);
                }

                foreach (var reservationByDelete in reservationsByDelete)
                    _reservationService.Delete(reservationByDelete.Id);


                return new JsonFactory().Success(MessageConstants.Save);
            }
            catch (Exception e)
            {
                return new JsonFactory().Failure(e.GetType(), e.Message);
            }
        }


    }
}