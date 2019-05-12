using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Models;
using FoodManager.Models.BaseResponses;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class DiseaseService : IDiseaseService
    {
        public Disease Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Disease, id);
            return Request.Get<Disease>(uri);
        }

        public DiseasePage Filter(DiseaseFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Disease);
            return Request.Filter<DiseasePage>(uri, request);
        }

        public List<Disease> OnlyStatusActivated()
        {
            var request = new DiseaseFilter { OnlyStatusActivated = true };
            return Filter(request).Diseases;
        }

        public void Create(Disease request)
        {
            var uri = String.Format(PluralEntityConstants.Disease);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Disease request)
        {
            var uri = String.Format(PluralEntityConstants.Disease);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Disease, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Disease, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Disease, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

    }
}