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
    public class IngredientService : IIngredientService
    {
        public Ingredient Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Ingredient, id);
            return Request.Get<Ingredient>(uri);
        }

        public IngredientPage Filter(IngredientFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Ingredient);
            return Request.Filter<IngredientPage>(uri, request);
        }

        public List<Ingredient> OnlyStatusActivated()
        {
            var request = new IngredientFilter { OnlyStatusActivated = true };
            return Filter(request).Ingredients;
        }

        public void Create(Ingredient request)
        {
            var uri = String.Format(PluralEntityConstants.Ingredient);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Ingredient request)
        {
            var uri = String.Format(PluralEntityConstants.Ingredient);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Ingredient, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Ingredient, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Ingredient, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

    }
}