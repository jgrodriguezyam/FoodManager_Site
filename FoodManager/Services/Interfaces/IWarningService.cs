using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IWarningService
    {
        Warning Get(int id);
        WarningPage Filter(WarningFilter request);
        List<Warning> OnlyStatusActivated();
        void Create(Warning request);
        void Update(Warning request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
    }
}