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
    public class DepartmentService : IDepartmentService
    {
        public Department Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Department, id);
            return Request.Get<Department>(uri);
        }

        public DepartmentPage Filter(DepartmentFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Department);
            return Request.Filter<DepartmentPage>(uri, request);
        }

        public List<Department> OnlyStatusActivated()
        {
            var request = new DepartmentFilter { OnlyStatusActivated = true };
            return Filter(request).Departments;
        }

        public void Create(Department request)
        {
            var uri = String.Format(PluralEntityConstants.Department);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Department request)
        {
            var uri = String.Format(PluralEntityConstants.Department);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Department, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Department, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Department, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }
    }
}