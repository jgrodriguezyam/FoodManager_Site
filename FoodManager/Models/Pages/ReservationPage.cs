using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class ReservationPage : Page
    {
        public ReservationPage()
        {
            Reservations = new List<Reservation>();
        }

        public List<Reservation> Reservations { get; set; }
    }
}