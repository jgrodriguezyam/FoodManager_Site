namespace FoodManager.Models.Filters
{
    public class UserFilter : SortingAndPagination
    {
        public UserFilter()
        {
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string Name { get; set; }
        public string UserName { get; set; }
        public string DealerId { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}