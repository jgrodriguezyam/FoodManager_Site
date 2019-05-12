using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class SaucerMultimediaPage : Page
    {
        public SaucerMultimediaPage()
        {
            SaucerMultimedias = new List<SaucerMultimedia>();
        }

        public List<SaucerMultimedia> SaucerMultimedias { get; set; }
    }
}