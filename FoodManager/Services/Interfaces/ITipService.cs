using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface ITipService
    {
        Tip Get(int id);
        TipPage Filter(TipFilter request);
        List<Tip> OnlyStatusActivated();
        void Create(Tip request);
        void Update(Tip request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
    }
}