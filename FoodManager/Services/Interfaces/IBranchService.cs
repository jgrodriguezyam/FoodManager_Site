using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IBranchService
    {
        Branch Get(int id);
        BranchPage Filter(BranchFilter request);
        List<Branch> OnlyStatusActivated();
        bool IsReference(int id);
        void Create(Branch request);
        void Update(Branch request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        void AssignDealer(int branchId, int dealerId);
        void AssignDealers(int branchId, IEnumerable<int> dealerIds);
        void RemoveDealer(int branchId, int dealerId);
        void RemoveDealers(int branchId, IEnumerable<int> dealerIds);
    }
}