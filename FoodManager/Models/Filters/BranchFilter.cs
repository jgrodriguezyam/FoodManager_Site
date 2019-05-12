namespace FoodManager.Models.Filters
{
    public class BranchFilter : SortingAndPagination
    {
        public BranchFilter()
        {
            Code = "";
            Name = "";
            RegionId = 0;
            CompanyId = 0;
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public int CompanyId { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}