using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IDealerService
    {
        Dealer Get(int id);
        DealerPage Filter(DealerFilter request);
        List<Dealer> OnlyStatusActivated();
        List<Dealer> OnlyWithBranchId(int branchId);
        void Create(Dealer request);
        void Update(Dealer request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}