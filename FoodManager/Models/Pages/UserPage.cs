using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class UserPage : Page
    {
        public UserPage()
        {
            Users = new List<User>();
        }

        public List<User> Users { get; set; }
    }
}