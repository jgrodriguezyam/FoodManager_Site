namespace FoodManager.Models.Reports
{
    public class Worker
    {
        public Worker()
        {
            WorkerId = 0;
            FirstName = "";
            LastName = "";
            ReservationCount = 0;
        }

        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ReservationCount { get; set; }
    }
}