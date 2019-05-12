using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class WarningPage : Page
    {
        public WarningPage()
        {
            Warnings = new List<Warning>();
        }

        public List<Warning> Warnings { get; set; }
    }
}