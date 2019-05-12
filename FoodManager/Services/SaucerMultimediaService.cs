using System;
using System.Collections.Generic;
using System.Web;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class SaucerMultimediaService : ISaucerMultimediaService
    {
        public SaucerMultimedia Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.SaucerMultimedia, id);
            return Request.Get<SaucerMultimedia>(uri);
        }

        public SaucerMultimediaPage Filter(SaucerMultimediaFilter request)
        {
            var uri = String.Format(PluralEntityConstants.SaucerMultimedia);
            return Request.Filter<SaucerMultimediaPage>(uri, request);
        }

        public List<SaucerMultimedia> OnlyStatusActivated()
        {
            var request = new SaucerMultimediaFilter { OnlyStatusActivated = true };
            return Filter(request).SaucerMultimedias;
        }

        public List<SaucerMultimedia> OnlyWithSaucerId(int saucerId)
        {
            var request = new SaucerMultimediaFilter { SaucerId = saucerId, OnlyStatusActivated = true };
            return Filter(request).SaucerMultimedias;
        }

        public void Create(int saucerId, HttpPostedFileBase multimedia)
        {
            var uri = String.Format("{0}/saucers/{1}/file", PluralEntityConstants.SaucerMultimedia, saucerId);
            Request.AddFile(uri, multimedia);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.SaucerMultimedia, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.SaucerMultimedia, id, status);
            Request.Put(uri);
        }
    }
}