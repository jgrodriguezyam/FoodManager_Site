using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Models
{
    public class SaucerConfiguration
    {
        public SaucerConfiguration()
        {
            Id = 0;
            NetWeight = 0;
            Status = false;
            Saucer = new Saucer();
            Ingredient = new Ingredient();
        }

        public int Id { get; set; }
        public decimal NetWeight { get; set; }
        public bool Status { get; set; }

        public Saucer Saucer { get; set; }
        public int SaucerId
        {
            get { return Saucer.IsNotNull() ? Saucer.Id : 0; }
            set
            {
                Saucer.Id = value;
                Saucer.Name = "OnlyId";
            }
        }

        public Ingredient Ingredient { get; set; }
        public int IngredientId
        {
            get { return Ingredient.IsNotNull() ? Ingredient.Id : 0; }
            set
            {
                Ingredient.Id = value;
                Ingredient.Name = "OnlyId";
            }
        }
    }
}