using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class SaucerConfigurationPage : Page
    {
        public SaucerConfigurationPage()
        {
            SaucerConfigurations = new List<SaucerConfiguration>();
        }

        public List<SaucerConfiguration> SaucerConfigurations { get; set; }
    }
}