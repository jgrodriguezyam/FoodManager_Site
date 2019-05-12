using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface ICompanyService
    {
        Company Get(int id);
        CompanyPage Filter(CompanyFilter request);
        List<Company> OnlyStatusActivated();
        void Create(Company request);
        void Update(Company request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}