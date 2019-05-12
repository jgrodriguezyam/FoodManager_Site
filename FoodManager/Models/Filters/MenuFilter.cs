namespace FoodManager.Models.Filters
{
    public class MenuFilter : SortingAndPagination
    {
        public MenuFilter()
        {
            DaysWeek = "";
            DealerId = 0;
            SaucerId = 0;
            Date = "";
            OnlyToday = false;
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string DaysWeek { get; set; }
        public int DealerId { get; set; }
        public int SaucerId { get; set; }
        public string Date { get; set; }
        public bool OnlyToday { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}