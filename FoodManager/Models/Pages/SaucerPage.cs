using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class SaucerPage : Page
    {
        public SaucerPage()
        {
            Saucers = new List<Saucer>();
        }

        public List<Saucer> Saucers { get; set; }
    }
}