using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IDiseaseService
    {
        Disease Get(int id);
        DiseasePage Filter(DiseaseFilter request);
        List<Disease> OnlyStatusActivated();
        void Create(Disease request);
        void Update(Disease request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}