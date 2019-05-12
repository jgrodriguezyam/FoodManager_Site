namespace FoodManager.Models.Reports
{
    public class ReservationReport
    {
        public ReservationReport()
        {
            WorkerId = 0;
            StartDate = "";
            EndDate = "";
        }

        public int WorkerId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}