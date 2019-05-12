namespace FoodManager.Models.Filters
{
    public class WorkerFilter : SortingAndPagination
    {
        public WorkerFilter()
        {
            CompanyId = 0;
            DepartmentId = 0;
            JobId = 0;
            RoleId = 0;
            BranchId = 0;
            Code = "";
            Email = "";
            Badge = "";
            Imss = "";
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
            IsReport = false;
            Month = 0;
        }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Badge { get; set; }
        public string Imss { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
        public bool IsReport { get; set; }
        public int Month { get; set; }
    }
}