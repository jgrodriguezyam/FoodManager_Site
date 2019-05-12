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
    public class SaucerConfigurationService : ISaucerConfigurationService
    {
        public SaucerConfiguration Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.SaucerConfiguration, id);
            return Request.Get<SaucerConfiguration>(uri);
        }

        public SaucerConfigurationPage Filter(SaucerConfigurationFilter request)
        {
            var uri = String.Format(PluralEntityConstants.SaucerConfiguration);
            return Request.Filter<SaucerConfigurationPage>(uri, request);
        }

        public List<SaucerConfiguration> OnlyWithSaucerId(int saucerId)
        {
            var request = new SaucerConfigurationFilter { SaucerId = saucerId, OnlyStatusActivated = true };
            return Filter(request).SaucerConfigurations;
        }

        public List<SaucerConfiguration> OnlyStatusActivated()
        {
            var request = new SaucerConfigurationFilter { OnlyStatusActivated = true };
            return Filter(request).SaucerConfigurations;
        }

        public void Create(SaucerConfiguration request)
        {
            var uri = String.Format(PluralEntityConstants.SaucerConfiguration);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(SaucerConfiguration request)
        {
            var uri = String.Format(PluralEntityConstants.SaucerConfiguration);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.SaucerConfiguration, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.SaucerConfiguration, id, status);
            Request.Put(uri);
        }
    }
}