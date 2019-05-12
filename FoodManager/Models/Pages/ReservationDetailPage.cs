using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class ReservationDetailPage : Page
    {
        public ReservationDetailPage()
        {
            ReservationDetails = new List<ReservationDetail>();
        }

        public List<ReservationDetail> ReservationDetails { get; set; }
    }
}