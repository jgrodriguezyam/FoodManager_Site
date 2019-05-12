using System;
using System.Web.Mvc;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class ReservationDetailController : Controller
    {
        private readonly IReservationDetailService _reservationDetailService;

        public ReservationDetailController(IReservationDetailService reservationDetailService)
        {
            _reservationDetailService = reservationDetailService;
        }

        [HttpGet]
        public JsonResult Filter(ReservationDetailFilter filter)
        {
            try
            {
                var response = _reservationDetailService.Filter(filter);
                foreach (var reservationDetail in response.ReservationDetails)
                {
                    var currentReservationDetail = _reservationDetailService.Get(reservationDetail.Id);
                    reservationDetail.Ingredient = currentReservationDetail.Ingredient;
                    reservationDetail.Reservation = currentReservationDetail.Reservation;
                }
                return new JsonFactory().Success(response.ReservationDetails, response.TotalRecords);
            }
            catch (Exception e)
            {
                return new JsonFactory().Failure(e.GetType(),e.Message);
            }
        }

    }
}