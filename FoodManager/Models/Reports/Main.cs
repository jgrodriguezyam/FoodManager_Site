namespace FoodManager.Models.Reports
{
    public class Main
    {
        public Main()
        {
            SaucerId = 0;
            Name = "";
            Count = 0;
        }

        public int SaucerId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}