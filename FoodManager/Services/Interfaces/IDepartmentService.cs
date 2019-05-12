using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IDepartmentService
    {
        Department Get(int id);
        DepartmentPage Filter(DepartmentFilter request);
        List<Department> OnlyStatusActivated();
        void Create(Department request);
        void Update(Department request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
        bool IsReference(int id);
    }
}