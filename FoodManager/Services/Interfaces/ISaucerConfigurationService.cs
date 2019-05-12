using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface ISaucerConfigurationService
    {
        SaucerConfiguration Get(int id);
        SaucerConfigurationPage Filter(SaucerConfigurationFilter request);
        List<SaucerConfiguration> OnlyStatusActivated();
        List<SaucerConfiguration> OnlyWithSaucerId(int saucerId);
        void Create(SaucerConfiguration request);
        void Update(SaucerConfiguration request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
    }
}