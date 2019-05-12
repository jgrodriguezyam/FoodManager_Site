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
using FoodManager.Models.Reports;
using FoodManager.Services.Interfaces;
using Worker = FoodManager.Models.Worker;

namespace FoodManager.Services
{
    public class WorkerService : IWorkerService
    {
        public void Login(WorkerLogin request)
        {
            var uriLogin = String.Format("{0}/login", PluralEntityConstants.Worker);
            SessionSettings.AssignAllSessions();
            SessionSettings.AssignLoginType(LoginType.Worker);
            
            var loginResponse = Request.Login<WorkerLoginResponse>(uriLogin, request);
            SessionSettings.AssignPublicKey(loginResponse.PublicKey);
            SessionSettings.AssignWorkerId(loginResponse.WorkerId);
            SessionSettings.AssignBadge(request.Badge);

            var workerResponse = Get(loginResponse.WorkerId);
            SessionSettings.AssignFirstName(workerResponse.FirstName);
            SessionSettings.AssignBranchId(workerResponse.BranchId);
            SessionSettings.AssignLimitEnergy(workerResponse.LimitEnergy);
        }

        public void Logout()
        {
            var uriLogout = String.Format("{0}/logout/{1}", PluralEntityConstants.Worker, SessionSettings.RetrieveWorkerId);
            Request.Logout(uriLogout);
        }

        public Worker Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Worker, id);
            return Request.Get<Worker>(uri);
        }

        public WorkerPage Filter(WorkerFilter request)
        {
            var uri = String.Format("{0}", PluralEntityConstants.Worker);
            return Request.Filter<WorkerPage>(uri, request);
        }

        public List<Worker> OnlyStatusActivated()
        {
            var request = new WorkerFilter { OnlyStatusActivated = true };
            return Filter(request).Workers;
        }

        public void Create(Worker request)
        {
            var uri = String.Format("{0}", PluralEntityConstants.Worker);
            var result = Request.Post(uri, request);
            request.Id = result.Id;
        }

        public void Update(Worker request)
        {
            var uri = String.Format("{0}", PluralEntityConstants.Worker);
            Request.Put(uri, request);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Worker, id, status);
            Request.Put(uri);
        }

        public bool IsReference(int id)
        {
            var uri = String.Format("{0}/is-reference/{1}", PluralEntityConstants.Worker, id);
            return Request.Get<SuccessResponse>(uri).IsSuccess;
        }

        public WorkerReportResponse Report(WorkerReport request)
        {
            var uri = string.Format("{0}/report", PluralEntityConstants.Worker);
            return Request.Filter<WorkerReportResponse>(uri, request);
        }
    }
}