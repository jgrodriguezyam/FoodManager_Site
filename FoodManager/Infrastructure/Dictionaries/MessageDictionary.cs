using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;

namespace FoodManager.Infrastructure.Dictionaries
{
    public static class MessageDictionary
    {
        public static readonly IDictionary<EntityType, string> MessageToEntityType = new Dictionary<EntityType, string>
        {            
            {EntityType.Branch, MessageConstants.InactiveBranch},
            {EntityType.Company, MessageConstants.InactiveCompany},
            {EntityType.Dealer, MessageConstants.InactiveDealer},
            {EntityType.Department, MessageConstants.InactiveDepartment},
            {EntityType.Disease, MessageConstants.InactiveDisease},
            {EntityType.IngredientGroup, MessageConstants.InactiveIngredientGroup},
            {EntityType.Job, MessageConstants.InactiveJob},
            {EntityType.Region, MessageConstants.InactiveRegion},
            {EntityType.Saucer, MessageConstants.InactiveSaucer}
        };
    }
}