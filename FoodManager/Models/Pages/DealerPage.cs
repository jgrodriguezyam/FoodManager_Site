using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class DealerPage : Page
    {
        public DealerPage()
        {
            Dealers = new List<Dealer>();
        }

        public List<Dealer> Dealers { get; set; }
    }
}