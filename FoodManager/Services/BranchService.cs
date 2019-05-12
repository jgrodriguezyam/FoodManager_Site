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
    public class BranchService : IBranchService
    {
        public Branch Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Branch, id);
            return Request.Get<Branch>(uri);
        }

        public BranchPage Filter(BranchFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Branch);
            return Request.Filter<BranchPage>(uri, request);
        }

        public List<Branch> OnlyStatusActivated()
        {
            var request = new BranchFilter {OnlyStatusActivated = true};
            return Filter(request).Branches;
        }

        public void Create(Branch request)
        {
            var uri = String.Format(PluralEntityConstants.Branch);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Branch request)
        {
            var uri = String.Format(PluralEntityConstants.Branch);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Branch, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Branch, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Branch, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

        public void AssignDealer(int branchId, int dealerId)
        {
            var uri = String.Format("{0}/{1}/dealers/{2}", PluralEntityConstants.Branch, branchId, dealerId);
            Request.Assign(uri);
        }

        public void AssignDealers(int branchId, IEnumerable<int> dealerIds)
        {
            foreach (var dealerId in dealerIds)
                AssignDealer(branchId, dealerId);
        }

        public void RemoveDealer(int branchId, int dealerId)
        {
            var uri = String.Format("{0}/{1}/dealers/{2}", PluralEntityConstants.Branch, branchId, dealerId);
            Request.UnAssign(uri);
        }

        public void RemoveDealers(int branchId, IEnumerable<int> dealerIds)
        {
            foreach (var dealerId in dealerIds)
                RemoveDealer(branchId, dealerId);
        }
    }
}