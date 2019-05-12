using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Models.Reports;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class ReservationService : IReservationService
    {
        public Reservation Get(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Reservation, id);
            return Request.Get<Reservation>(uri);
        }

        public ReservationPage Filter(ReservationFilter request)
        {
            if (SessionSettings.ExistsWorkerId)
                request.WorkerId = SessionSettings.RetrieveWorkerId;

            var uri = string.Format(PluralEntityConstants.Reservation);
            return Request.Filter<ReservationPage>(uri, request);
        }

        public List<Reservation> OnlyStatusActivated()
        {
            var request = new ReservationFilter { OnlyStatusActivated = true };
            if (SessionSettings.ExistsWorkerId)
                request.WorkerId = SessionSettings.RetrieveWorkerId;
            return Filter(request).Reservations;
        }

        public void Create(Reservation request)
        {
            request.WorkerId = SessionSettings.RetrieveWorkerId;
            var uri = string.Format(PluralEntityConstants.Reservation);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Reservation request)
        {
            request.WorkerId = SessionSettings.RetrieveWorkerId;
            var uri = string.Format(PluralEntityConstants.Reservation);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Reservation, id);
            Request.Delete(uri);
        }

        public ReservationReportResponse Report(ReservationReport request)
        {
            var uri = string.Format("{0}/report",PluralEntityConstants.Reservation);
            return Request.Filter<ReservationReportResponse>(uri, request);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Reservation, id, status);
            Request.Put(uri);
        }
    }
}