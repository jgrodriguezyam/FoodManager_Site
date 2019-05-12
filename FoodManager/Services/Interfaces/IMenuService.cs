using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IMenuService
    {
        Menu Get(int id);
        MenuPage Filter(MenuFilter request);
        List<Menu> OnlyStatusActivated();
        void Create(Menu request);
        void Update(Menu request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
    }
}