using System.Collections.Generic;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Models
{
    public class Saucer
    {
        public Saucer()
        {
            Id = 0;
            Name = "";
            IsReference = false;
            NutritionInformation = new NutritionInformation();
            SaucerConfigurations = new List<SaucerConfiguration>();
            SaucerMultimedias = new List<SaucerMultimedia>();
            Type = new SaucerType();
            Status = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReference { get; set; }
        public NutritionInformation NutritionInformation { get; set; }
        public List<SaucerConfiguration> SaucerConfigurations { get; set; }
        public List<SaucerMultimedia> SaucerMultimedias { get; set; }
        public SaucerType Type { get; set; }
        public string TypeLabel
        {
            get { return EnumResolver.Saucer(Type.GetValue()); }
        }
        public bool Status { get; set; }
    }
}