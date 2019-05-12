namespace FoodManager.Models
{
    public class Region
    {
        public Region()
        {
            Id = 0;
            Name = "";
            Status = false;
            IsReference = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set ; }
    }
}