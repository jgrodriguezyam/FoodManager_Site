namespace FoodManager.Models.Reports
{
    public class Garrison
    {
        public Garrison()
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