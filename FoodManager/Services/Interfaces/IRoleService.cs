using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IRoleService
    {
        Role Get(int id);
        RolePage Filter(RoleFilter request);
        List<Role> OnlyStatusActivated();
        bool IsReference(int id);
        void Create(Role request);
        void Update(Role request);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
    }
}