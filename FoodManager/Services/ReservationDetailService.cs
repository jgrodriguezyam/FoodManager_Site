using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class ReservationDetailService : IReservationDetailService
    {
        public ReservationDetail Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.ReservationDetail, id);
            return Request.Get<ReservationDetail>(uri);
        }

        public ReservationDetailPage Filter(ReservationDetailFilter request)
        {
            var uri = String.Format(PluralEntityConstants.ReservationDetail);
            return Request.Filter<ReservationDetailPage>(uri, request);
        }
    }
}