namespace FoodManager.Models.Filters
{
    public class JobFilter : SortingAndPagination
    {
        public JobFilter()
        {
            Name = "";
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string Name { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}