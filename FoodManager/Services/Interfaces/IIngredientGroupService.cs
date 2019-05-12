using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IIngredientGroupService
    {
        IngredientGroup Get(int id);
        IngredientGroupPage Filter(IngredientGroupFilter request);
        List<IngredientGroup> OnlyStatusActivated();
        void Create(IngredientGroup request);
        void Update(IngredientGroup request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}