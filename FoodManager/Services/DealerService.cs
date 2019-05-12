using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Models.BaseResponses;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class DealerService : IDealerService
    {
        public Dealer Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Dealer, id);
            return Request.Get<Dealer>(uri);
        }

        public DealerPage Filter(DealerFilter request)
        {
            if (SessionSettings.ExistsBranchId)
                request.BranchId = SessionSettings.RetrieveBranchId;
            if(SessionSettings.RetrieveLoginType == LoginType.User)
                request.BranchId = request.BranchId;

            var uri = String.Format(PluralEntityConstants.Dealer);
            return Request.Filter<DealerPage>(uri, request);
        }

        public List<Dealer> OnlyStatusActivated()
        {
            var request = new DealerFilter { OnlyStatusActivated = true }; 
            if (SessionSettings.ExistsBranchId)
                request.BranchId = SessionSettings.RetrieveBranchId;
            return Filter(request).Dealers;
        }

        public List<Dealer> OnlyWithBranchId(int branchId)
        {
            var request = new DealerFilter { BranchId = branchId, OnlyStatusActivated = true };
            return Filter(request).Dealers;
        }

        public void Create(Dealer request)
        {
            var uri = String.Format(PluralEntityConstants.Dealer);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Dealer request)
        {
            var uri = String.Format(PluralEntityConstants.Dealer);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Dealer, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Dealer, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Dealer, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }
    }
}