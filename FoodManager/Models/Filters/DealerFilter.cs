namespace FoodManager.Models.Filters
{
    public class DealerFilter : SortingAndPagination
    {
        public DealerFilter()
        {
            Name = "";
            BranchId = 0;
            WithoutBranchId = 0;
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string Name { get; set; }
        public int BranchId { get; set; }
        public int WithoutBranchId { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}