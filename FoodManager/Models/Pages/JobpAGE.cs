using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class JobPage : Page
    {
        public JobPage()
        {
            Jobs = new List<Job>();
        }

        public List<Job> Jobs { get; set; }
    }
}