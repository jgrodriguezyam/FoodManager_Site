using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Models;
using FoodManager.Models.BaseResponses;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Models.Reports;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class SaucerService : ISaucerService
    {
        public Saucer Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Saucer, id);
            return Request.Get<Saucer>(uri);
        }

        public SaucerPage Filter(SaucerFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Saucer);
            return Request.Filter<SaucerPage>(uri, request);
        }

        public List<Saucer> OnlyStatusActivated()
        {
            var request = new SaucerFilter { OnlyStatusActivated = true };
            return Filter(request).Saucers;
        }

        public void Create(Saucer request)
        {
            var uri = String.Format(PluralEntityConstants.Saucer);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Saucer request)
        {
            var uri = String.Format(PluralEntityConstants.Saucer);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Saucer, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Saucer, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Saucer, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

        public NutritionInformation NutritionInformation(int id)
        {
            var uri = String.Format("{0}/{1}/nutrition-informations", PluralEntityConstants.Saucer, id);
            return Request.Get<NutritionInformation>(uri);
        }

        public SaucerReportResponse Report(SaucerReport request)
        {
            var uri = string.Format("{0}/report", PluralEntityConstants.Saucer);
            return Request.Filter<SaucerReportResponse>(uri, request);
        }

    }
}