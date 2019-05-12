using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class DiseasePage : Page
    {
        public DiseasePage()
        {
            Diseases = new List<Disease>();
        }

        public List<Disease> Diseases { get; set; }
    }
}