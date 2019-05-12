using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Id = 0;
            Name = "";
            NetWeight = 0;
            Energy = 0;
            Protein = 0;
            Carbohydrate = 0;
            Sugar = 0;
            Lipid = 0;
            Sodium = 0;
            Status = false;
            IsReference = false;
            Unit = new UnitType();
            IngredientGroup = new IngredientGroup();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Energy { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Sugar { get; set; }
        public decimal Lipid { get; set; }
        public decimal Sodium { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set; }
        public UnitType Unit { get; set; }
        public string UnitLabel
        {
            get { return EnumResolver.Unit(Unit.GetValue()); }
        }

        public IngredientGroup IngredientGroup { get; set; }
        public int IngredientGroupId
        {
            get { return IngredientGroup.IsNotNull() ? IngredientGroup.Id : 0; }
            set
            {
                IngredientGroup.Id = value;
                IngredientGroup.Name = "OnlyId";
            }
        }
    }
}