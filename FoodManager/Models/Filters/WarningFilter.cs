namespace FoodManager.Models.Filters
{
    public class WarningFilter : SortingAndPagination
    {
        public WarningFilter()
        {
            Code = "";
            Name = "";
            DiseaseId = 0;
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int DiseaseId { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}