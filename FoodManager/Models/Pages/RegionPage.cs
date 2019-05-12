using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class RegionPage : Page
    {
        public RegionPage()
        {
            Regions = new List<Region>();
        }

        public List<Region> Regions { get; set; }
    }
}