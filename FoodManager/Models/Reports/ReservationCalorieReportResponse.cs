namespace FoodManager.Models.Reports
{
    public class ReservationCalorieReportResponse
    {
        public ReservationCalorieReportResponse()
        {
            BreakFast = 0;
            Lunch = 0;
            Dinner = 0;
            Date = "";
        }

        public decimal BreakFast { get; set; }
        public decimal Lunch { get; set; }
        public decimal Dinner { get; set; }
        public string Date { get; set; }
    }
}