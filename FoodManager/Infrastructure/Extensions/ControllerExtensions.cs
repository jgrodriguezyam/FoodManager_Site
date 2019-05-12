using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Dictionaries;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Factories;

namespace FoodManager.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static void NotifyInactiveReferences(this ControllerBase controller, object @object, List<EntityType> entityTypeToReferences)
        {
            var multiMessages = String.Empty;
            foreach (var entityTypeToReference in entityTypeToReferences)
            {
                var objectRetrieved = @object.ExtractProperty(entityTypeToReference.ToString());
                var id = objectRetrieved.ExtractProperty<int>("Id");
                var status = objectRetrieved.ExtractProperty<bool>("Status");

                if (id.IsGreaterThanZero() && !status)
                {
                    var message = MessageDictionary.MessageToEntityType[entityTypeToReference];
                    multiMessages += multiMessages.IsNotNullOrEmpty() ? " - " : "";
                    multiMessages += String.Format(message, objectRetrieved.ExtractName());
                }
            }

            if(multiMessages.IsNotNullOrEmpty())
                new TempDataFactory().CreateWarning(controller, multiMessages);
        }

        public static void NotifyInactiveReference(this ControllerBase controller, object @object, EntityType entityTypeToReference)
        {
            NotifyInactiveReferences(controller,@object, new List<EntityType>{entityTypeToReference});
        }

        public static void NotifyWithoutAssign(this ControllerBase controller, object @object)
        {
            var status = @object.ExtractProperty<bool>("Status");
            if(!status)
                new TempDataFactory().CreateInformation(controller, MessageConstants.FormWithoutAssign);
        }

        public static void NotifyWithoutAssigns(this ControllerBase controller, object @object)
        {
            var status = @object.ExtractProperty<bool>("Status");
            if (!status)
                new TempDataFactory().CreateInformation(controller, MessageConstants.FormWithoutAssigns);
        }

        public static void NotifyInvalidRangeDate(this ControllerBase controller, string startDate, string endDate)
        {
            if (startDate.ConvertToDateTime().IsLessThanToday() && endDate.ConvertToDateTime().IsLessThanToday())
                new TempDataFactory().CreateInformation(controller, String.Format(MessageConstants.InvalidRangeDates, startDate, endDate));
            else if (startDate.ConvertToDateTime().IsLessThanToday())
                new TempDataFactory().CreateInformation(controller, String.Format(MessageConstants.InvalidStartDate, startDate));
        }
    }
}