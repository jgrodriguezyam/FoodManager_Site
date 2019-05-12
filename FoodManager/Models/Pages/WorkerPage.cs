using System.Collections.Generic;

namespace FoodManager.Models.Pages
{
    public class WorkerPage : Page
    {
        public WorkerPage()
        {
            Workers = new List<Worker>();
        }

        public List<Worker> Workers { get; set; }
    }
}