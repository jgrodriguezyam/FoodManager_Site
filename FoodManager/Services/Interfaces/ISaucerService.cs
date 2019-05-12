using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Models.Reports;

namespace FoodManager.Services.Interfaces
{
    public interface ISaucerService
    {
        Saucer Get(int id);
        SaucerPage Filter(SaucerFilter request);
        List<Saucer> OnlyStatusActivated();
        NutritionInformation NutritionInformation(int id);
        void Create(Saucer request);
        void Update(Saucer request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
        SaucerReportResponse Report(SaucerReport request);
    }
}