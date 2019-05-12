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
    public class RegionService : IRegionService
    {
        public Region Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Region, id);
            return Request.Get<Region>(uri);
        }

        public RegionPage Filter(RegionFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Region);
            return Request.Filter<RegionPage>(uri, request);
        }

        public List<Region> OnlyStatusActivated()
        {
            var request = new RegionFilter { OnlyStatusActivated = true };
            return Filter(request).Regions;
        }

        public void Create(Region request)
        {
            var uri = String.Format(PluralEntityConstants.Region);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Region request)
        {
            var uri = String.Format(PluralEntityConstants.Region);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Region, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Region, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Region, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }
    }
}