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
    public class JobService : IJobService
    {
        public Job Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Job, id);
            return Request.Get<Job>(uri);
        }

        public JobPage Filter(JobFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Job);
            return Request.Filter<JobPage>(uri, request);
        }

        public List<Job> OnlyStatusActivated()
        {
            var request = new JobFilter { OnlyStatusActivated = true };
            return Filter(request).Jobs;
        }

        public void Create(Job request)
        {
            var uri = String.Format(PluralEntityConstants.Job);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Job request)
        {
            var uri = String.Format(PluralEntityConstants.Job);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Job, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Job, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Job, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

    }
}