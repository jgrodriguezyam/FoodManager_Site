namespace FoodManager.Models.Filters
{
    public class DiseaseFilter : SortingAndPagination
    {
        public DiseaseFilter()
        {
            Code = "";
            Name = "";
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}