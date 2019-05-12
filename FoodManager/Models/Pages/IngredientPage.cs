using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class IngredientPage : Page
    {
        public IngredientPage()
        {
            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }
    }
}