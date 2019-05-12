using System.Collections.Generic;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
namespace FoodManager.Infrastructure.Dictionaries
{
    public static class ActionDictionary
    {
        public static readonly IDictionary<string, string> DisplayToActionType = new Dictionary<string, string>
        {            
            {ActionType.New.ToString(), DisplayConstants.Create},
            {ActionType.Edit.ToString(), DisplayConstants.Update},
            {ActionType.Create.ToString(), DisplayConstants.Update},
        };
    }
}