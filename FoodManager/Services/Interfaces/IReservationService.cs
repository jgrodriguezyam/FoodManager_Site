using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Models.Reports;

namespace FoodManager.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation Get(int id);
        ReservationPage Filter(ReservationFilter request);
        List<Reservation> OnlyStatusActivated();
        void Create(Reservation request);
        void Update(Reservation request);
        void Delete(int id);
        ReservationReportResponse Report(ReservationReport request);
    }
}