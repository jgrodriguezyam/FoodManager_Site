using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class IngredientGroupPage : Page
    {
        public IngredientGroupPage()
        {
            IngredientGroups = new List<IngredientGroup>();
        }

        public List<IngredientGroup> IngredientGroups { get; set; }
    }
}