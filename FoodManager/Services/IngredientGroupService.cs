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
    public class IngredientGroupService : IIngredientGroupService
    {
        public IngredientGroup Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.IngredientGroup, id);
            return Request.Get<IngredientGroup>(uri);
        }

        public IngredientGroupPage Filter(IngredientGroupFilter request)
        {
            var uri = String.Format(PluralEntityConstants.IngredientGroup);
            return Request.Filter<IngredientGroupPage>(uri, request);
        }

        public List<IngredientGroup> OnlyStatusActivated()
        {
            var request = new IngredientGroupFilter { OnlyStatusActivated = true };
            return Filter(request).IngredientGroups;
        }

        public void Create(IngredientGroup request)
        {
            var uri = String.Format(PluralEntityConstants.IngredientGroup);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(IngredientGroup request)
        {
            var uri = String.Format(PluralEntityConstants.IngredientGroup);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.IngredientGroup, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.IngredientGroup, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.IngredientGroup, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

    }
}