using System.Collections.Generic;

namespace FoodManager.Models.Reports
{
    public class ReservationReportResponse
    {
        public ReservationReportResponse()
        {
            Calories = new List<ReservationCalorieReportResponse>();
        }

        public List<ReservationCalorieReportResponse> Calories { get; set; }

    }
}