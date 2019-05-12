using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class MenuPage : Page
    {
        public MenuPage()
        {
            Menus = new List<Menu>();
        }

        public List<Menu> Menus { get; set; }
    }
}