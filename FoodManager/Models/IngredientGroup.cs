namespace FoodManager.Models
{
    public class IngredientGroup
    {
        public IngredientGroup()
        {
            Id = 0;
            Name = "";
            Color = "";
            Status = false;
            IsReference = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set; }
    }
}