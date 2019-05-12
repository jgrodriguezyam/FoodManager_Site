namespace FoodManager.Models.Filters
{
    public class IngredientFilter : SortingAndPagination
    {
        public IngredientFilter()
        {
            Name = "";
            WithoutIds = "";
            WithIds = "";
            IngredientGroupId = 0;
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public string Name { get; set; }
        public int IngredientGroupId { get; set; }
        public string WithoutIds { get; set; }
        public string WithIds { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}