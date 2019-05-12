using System.Collections.Generic;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface IUserService
    {
        void Login(UserLogin request);
        void Logout();
        User Get(int id);
        UserPage Filter(UserFilter request);
        List<User> OnlyStatusActivated();
        void Create(User request);
        void Update(User request);
        void ChangePassword(ChangePassword changePassword);
        void ChangeStatus(int id, bool status);
    }
}