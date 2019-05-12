namespace FoodManager.Models.Filters
{
    public class IngredientGroupFilter : SortingAndPagination
    {
        public IngredientGroupFilter()
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