using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Enums;
using FoodManager.Models;

namespace FoodManager.Infrastructure.Dictionaries
{
    public static class ModelDictionary
    {
        public static readonly IDictionary<string, Type> ModelToEntityType = new Dictionary<string, Type>
        {            
            {EntityType.Branch.ToString(), typeof(Branch)},
            {EntityType.Company.ToString(), typeof(Company)},
            {EntityType.Dealer.ToString(), typeof(Dealer)},
            {EntityType.Department.ToString(), typeof(Department)},
            {EntityType.Disease.ToString(), typeof(Disease)},
            {EntityType.Ingredient.ToString(), typeof(Ingredient)},
            {EntityType.IngredientGroup.ToString(), typeof(IngredientGroup)},
            {EntityType.Job.ToString(), typeof(Job)},
            {EntityType.Menu.ToString(), typeof(Menu)},
            {EntityType.Region.ToString(), typeof(Region)},
            {EntityType.Tip.ToString(), typeof(Tip)},
            {EntityType.User.ToString(), typeof(User)},
            {EntityType.Warning.ToString(), typeof(Warning)},
            {EntityType.Saucer.ToString(), typeof(Saucer)},
            {EntityType.Worker.ToString(), typeof(Worker)}
        };
    }
}