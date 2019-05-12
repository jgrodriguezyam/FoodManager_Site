namespace FoodManager.Models.Filters
{
    public class ReservationFilter : SortingAndPagination
    {
        public ReservationFilter()
        {
            WorkerId = 0;
            SaucerId = 0;
            DealerId = 0;
            Date = "";
            WithoutDealer = false;
            OnlyToday = false;
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public int WorkerId { get; set; }
        public int SaucerId { get; set; }
        public int DealerId { get; set; }
        public string Date { get; set; }
        public bool OnlyToday { get; set; }
        public bool WithoutDealer { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}