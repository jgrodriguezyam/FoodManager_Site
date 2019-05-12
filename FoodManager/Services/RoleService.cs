using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Models;
using FoodManager.Models.BaseResponses;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class RoleService : IRoleService
    {
        public Role Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Role, id);
            return Request.Get<Role>(uri);
        }

        public RolePage Filter(RoleFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Role);
            return Request.Filter<RolePage>(uri, request);
        }

        public List<Role> OnlyStatusActivated()
        {
            var request = new RoleFilter {OnlyStatusActivated = true};
            return Filter(request).Roles;
        }

        public void Create(Role request)
        {
            var uri = String.Format(PluralEntityConstants.Role);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Role request)
        {
            var uri = String.Format(PluralEntityConstants.Role);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Role, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Role, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Role, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

    }
}