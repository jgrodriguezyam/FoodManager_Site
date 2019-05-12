namespace FoodManager.Models
{
    public class NutritionInformation 
    {
        public NutritionInformation()
        {
            Energy = 0;
            Protein = 0;
            Carbohydrate = 0;
            Sugar = 0;
            Lipid = 0;
            Sodium = 0;
        }

        public decimal Energy { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Sugar { get; set; }
        public decimal Lipid { get; set; }
        public decimal Sodium { get; set; }
    }
}