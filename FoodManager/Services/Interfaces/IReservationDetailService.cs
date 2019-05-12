using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IReservationDetailService
    {
        ReservationDetail Get(int id);
        ReservationDetailPage Filter(ReservationDetailFilter request);
    }
}