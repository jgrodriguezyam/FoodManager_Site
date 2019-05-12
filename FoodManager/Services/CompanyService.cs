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
    public class CompanyService : ICompanyService
    {
        public Company Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Company, id);
            return Request.Get<Company>(uri);
        }

        public CompanyPage Filter(CompanyFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Company);
            return Request.Filter<CompanyPage>(uri, request);
        }

        public List<Company> OnlyStatusActivated()
        {
            var request = new CompanyFilter { OnlyStatusActivated = true };
            return Filter(request).Companies;
        }

        public void Create(Company request)
        {
            var uri = String.Format(PluralEntityConstants.Company);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Company request)
        {
            var uri = String.Format(PluralEntityConstants.Company);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Company, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Company, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Company, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }
    }
}