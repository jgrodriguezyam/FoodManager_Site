using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class TipPage : Page
    {
        public TipPage()
        {
            Tips = new List<Tip>();
        }

        public List<Tip> Tips { get; set; }
    }
}