namespace FoodManager.Models
{
    public class WorkerLogin
    {
        public WorkerLogin()
        {
            Badge = "";
            WithoutFilters = false;
        }

        public string Badge { get; set; }

        public bool WithoutFilters { get; set; }
    }
}