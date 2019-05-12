using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class RolePage : Page
    {
        public RolePage()
        {
            Roles = new List<Role>();
        }

        public List<Role> Roles { get; set; }
    }
}