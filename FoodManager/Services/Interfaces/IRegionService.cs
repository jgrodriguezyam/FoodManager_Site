using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IRegionService
    {
        Region Get(int id);
        RegionPage Filter(RegionFilter request);
        List<Region> OnlyStatusActivated();
        void Create(Region request);
        void Update(Region request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}