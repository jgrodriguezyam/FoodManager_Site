namespace FoodManager.Models.Filters
{
    public class CompanyFilter : SortingAndPagination
    {
        public CompanyFilter()
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