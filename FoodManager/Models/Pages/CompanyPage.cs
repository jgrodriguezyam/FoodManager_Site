using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class CompanyPage : Page
    {
        public CompanyPage()
        {
            Companies = new List<Company>();
        }

        public List<Company> Companies { get; set; }
    }
}