using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IIngredientService
    {
        Ingredient Get(int id);
        IngredientPage Filter(IngredientFilter request);
        List<Ingredient> OnlyStatusActivated();
        void Create(Ingredient request);
        void Update(Ingredient request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}