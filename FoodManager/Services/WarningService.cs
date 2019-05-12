using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class WarningService : IWarningService
    {
        public Warning Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Warning, id);
            return Request.Get<Warning>(uri);
        }

        public WarningPage Filter(WarningFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Warning);
            return Request.Filter<WarningPage>(uri, request);
        }

        public List<Warning> OnlyStatusActivated()
        {
            var request = new WarningFilter { OnlyStatusActivated = true };
            return Filter(request).Warnings;
        }

        public void Create(Warning request)
        {
            var uri = String.Format(PluralEntityConstants.Warning);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Warning request)
        {
            var uri = String.Format(PluralEntityConstants.Warning);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Warning, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Warning, id, status);
            Request.Put(uri);
        }
    }
}