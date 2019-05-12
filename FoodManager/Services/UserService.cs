using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Models.BaseResponses;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class UserService : IUserService
    {
        public void Login(UserLogin request)
        {

            var uriLogin = String.Format("{0}/login", PluralEntityConstants.User);
            SessionSettings.AssignAllSessions();
            SessionSettings.AssignLoginType(LoginType.User);

            var loginResponse = Request.Login<UserLoginResponse>(uriLogin, request);
            SessionSettings.AssignPublicKey(loginResponse.PublicKey);
            SessionSettings.AssignUserId(loginResponse.UserId);
            SessionSettings.AssignUserName(request.UserName);
            SessionSettings.AssignPassword(request.Password);
                SessionSettings.AssignDealerId(loginResponse.DealerId.GetValue());
        }

        public void Logout()
        {
            var uriLogout = String.Format("{0}/logout/{1}", PluralEntityConstants.User, SessionSettings.RetrieveUserId);
            Request.Logout(uriLogout);
        }

        public User Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.User, id);
            return Request.Get<User>(uri);
        }

        public UserPage Filter(UserFilter request)
        {
            var uri = String.Format("{0}", PluralEntityConstants.User);
            return Request.Filter<UserPage>(uri, request);
        }

        public List<User> OnlyStatusActivated()
        {
            var request = new UserFilter { OnlyStatusActivated = true };
            return Filter(request).Users;
        }

        public void Create(User request)
        {
            var uri = String.Format("{0}", PluralEntityConstants.User);
            var result = Request.Post(uri, request);
            request.Id = result.Id;
        }

        public void Update(User request)
        {
            var uri = String.Format("{0}", PluralEntityConstants.User);
            Request.Put(uri, request);
        }

        public void ChangePassword(ChangePassword changePassword)
        {
            var uri = String.Format("{0}/change-password", PluralEntityConstants.User);
            Request.Post(uri, changePassword);
            if (changePassword.UserName.IsEquals(SessionSettings.RetrieveUserName))
                SessionSettings.AssignPassword(changePassword.NewPassword);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.User, id, status);
            Request.Put(uri);
        }
    }
}