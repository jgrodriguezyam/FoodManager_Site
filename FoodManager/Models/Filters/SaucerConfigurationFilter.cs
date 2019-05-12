namespace FoodManager.Models.Filters
{
    public class SaucerConfigurationFilter : SortingAndPagination
    {
        public SaucerConfigurationFilter()
        {
            SaucerId = 0;
            SaucerIds = "";
            IngredientId = 0;
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public int SaucerId { get; set; }
        public string SaucerIds { get; set; }
        public int IngredientId { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}