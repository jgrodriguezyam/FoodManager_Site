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
    public class TipService : ITipService
    {
        public Tip Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Tip, id);
            return Request.Get<Tip>(uri);
        }

        public TipPage Filter(TipFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Tip);
            var response = Request.Filter<TipPage>(uri, request);
            return response;
        }

        public List<Tip> OnlyStatusActivated()
        {
            var request = new TipFilter { OnlyStatusActivated = true };
            return Filter(request).Tips;
        }

        public void Create(Tip request)
        {
            var uri = String.Format(PluralEntityConstants.Tip);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Tip request)
        {
            var uri = String.Format(PluralEntityConstants.Tip);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Tip, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Tip, id, status);
            Request.Put(uri);
        }
    }
}