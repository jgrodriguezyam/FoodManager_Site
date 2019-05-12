using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exceptions.AppSettings;
using FoodManager.Infrastructure.Exceptions.Session;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Security;
using FoodManager.Infrastructure.Settings;

namespace FoodManager.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SessionSettings.AssignContextModel(String.Empty);
            SessionSettings.AssignIdCreated(0);

            if (filterContext.IsNotEqualsToAccountOrLogin())
            {
                ValidateSerial();
                ValidateSession();
            }

            if (filterContext.ActionIsEqualsThan(ActionType.Create))
            {
                var contextModel = filterContext.ContextModel().Serialize();
                SessionSettings.AssignContextModel(contextModel);
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.ActionIsEqualsThan(ActionType.Create))
            {
                new TempDataFactory().CreateSuccess(filterContext.Controller, MessageConstants.Create);
            }

            if (filterContext.ActionIsEqualsThan(ActionType.Update))
            {
                new TempDataFactory().CreateSuccess(filterContext.Controller, MessageConstants.Update);
            }

            if (filterContext.ActionIsEqualsThan(ActionType.Edit))
            {
                if (filterContext.ControllerIsEqualsThan(EntityType.Branch))
                {
                    var branch = filterContext.ContextModel();
                    var references = new List<EntityType> { EntityType.Company, EntityType.Region };
                    filterContext.Controller.NotifyInactiveReferences(branch, references);
                    filterContext.Controller.NotifyWithoutAssign(branch);
                }

                if (filterContext.ControllerIsEqualsThan(EntityType.User))
                {
                    var user = filterContext.ContextModel();
                    var references = new List<EntityType> {EntityType.Dealer, EntityType.Role};
                    filterContext.Controller.NotifyInactiveReferences(user, references);
                }

                if (filterContext.ControllerIsEqualsThan(EntityType.Worker))
                {
                    var worker = filterContext.ContextModel();
                    var references = new List<EntityType>
                    {
                        EntityType.Branch,
                        EntityType.Department,
                        EntityType.Job,
                        EntityType.Role
                    };
                    filterContext.Controller.NotifyInactiveReferences(worker, references);
                }

                if (filterContext.ControllerIsEqualsThan(EntityType.Warning))
                {
                    var warning = filterContext.ContextModel();
                    filterContext.Controller.NotifyInactiveReference(warning, EntityType.Disease);
                }

                if (filterContext.ControllerIsEqualsThan(EntityType.Ingredient))
                {
                    var ingredient = filterContext.ContextModel();
                    filterContext.Controller.NotifyInactiveReference(ingredient, EntityType.IngredientGroup);
                }

                if (filterContext.ControllerIsEqualsThan(EntityType.Saucer))
                {
                    var saucer = filterContext.ContextModel();
                    filterContext.Controller.NotifyWithoutAssigns(saucer);
                }

                if (filterContext.ControllerIsEqualsThan(EntityType.Menu))
                {
                    var menu = filterContext.ContextModel();
                    var startDate = menu.ExtractProperty<string>("StartDate");
                    var endDate = menu.ExtractProperty<string>("EndDate");
                    var references = new List<EntityType> {EntityType.Dealer, EntityType.Saucer};
                    filterContext.Controller.NotifyInactiveReferences(menu, references);
                    filterContext.Controller.NotifyInvalidRangeDate(startDate, endDate);
                }
            }
        }

        private static void ValidateSerial()
        {
            var serialDecrypt = Cryptography.Decrypt(AppSettings.Serial).Split(' ');
            var date = serialDecrypt[0].ConvertToDateTime();
            var company = serialDecrypt[1];

            if (date < DateTime.Now.Date || company.IsNotEquals(SystemConstants.OrganizationName.ToUpper()))
                throw new InvalidSerialException();

            //if (AppSettings.Serial != "QsmqEzHMxBADQ1lh+qTM4Q5vtiy8dcHt")
            //    throw new InvalidSerialVersionException();
        }

        private static void ValidateSession()
        {
            if (!SessionSettings.ExistsWorkerId && !SessionSettings.ExistsUserId)
                throw new SessionNotFoundException();
        }
    }
}