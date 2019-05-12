using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exceptions.AppSettings;
using FoodManager.Infrastructure.Exceptions.Session;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Settings;

namespace FoodManager.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.OK;

            if (filterContext.IsAjaxRequest())
            {
                filterContext.Result = new JsonFactory().Failure(filterContext);
            }
            else
            {
                SetResult(filterContext);
                new TempDataFactory().CreateFailure(filterContext);
            }
        }

        public void SetResult(ExceptionContext filterContext)
        {
            if (filterContext.ActionIsEqualsThan(ActionType.Login))
            {
                SessionSettings.AssignAllSessions();

                 var tempData = filterContext.Controller.TempData;
                filterContext.Result = new ViewResult {ViewName = ActionType.Login.ToString(), TempData = tempData};
            }

            if (filterContext.ControllerIsEqualsThan(EntityType.Account))
            {
                var tempData = filterContext.Controller.TempData;
                filterContext.Result = new ViewResult {ViewName = ActionType.Login.ToString(), TempData = tempData};
            }

            if (filterContext.ActionIsEqualsThan(ActionType.ChangePassword))
            {
                var routeValue = new RouteValueDictionary(new { controller = EntityType.Account, action = ActionType.Login });
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }

            if (filterContext.ActionIsEqualsThan(ActionType.New))
            {
                var routeValue = new RouteValueDictionary(new { controller = filterContext.ControllerName(), action = ActionType.Index});
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }

            if (filterContext.ActionIsEqualsThan(ActionType.Edit))
            {
                var routeValue = new RouteValueDictionary(new { controller = filterContext.ControllerName(), action = ActionType.Index });
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }

            if (filterContext.ActionIsEqualsThan(ActionType.Export))
            {
                new TempDataFactory().RemoveFailure(filterContext.ControllerBase());
                var csv = new CsvExport().RetrieveError();
                var stream = new StreamFactory().Csv(csv, "Error");
                filterContext.Result = stream;
            }

            if (filterContext.ActionIsEqualsThan(ActionType.Create))
            {
                var idCreated = SessionSettings.RetrieveIdCreated;
                if (idCreated.IsGreaterThanZero())
                {
                    var routeValue =  new RouteValueDictionary( new {controller = filterContext.ControllerName(), action = ActionType.Edit, id = idCreated});
                    filterContext.Result = new RedirectToRouteResult(routeValue);
                }
                else
                {
                    var contextModel = filterContext.DeserializeContext(SessionSettings.RetrieveContextModel);
                    var viewData = idCreated.IsGreaterThanZero() ? new { id = idCreated } : contextModel;
                    var tempData = filterContext.Controller.TempData;
                    filterContext.Result = new ViewResult { ViewName = ActionType.New.ToString(), ViewData = new ViewDataDictionary(viewData), TempData = tempData };
                }
            }

            if (filterContext.ActionIsEqualsThan(ActionType.Update))
            {
                var routeValue = new RouteValueDictionary(new { controller = filterContext.ControllerName(), action = ActionType.Edit, id = filterContext.IdToRequest() });
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }

            if (filterContext.Exception.GetType() == typeof(SessionNotFoundException) || filterContext.Exception.GetType() == typeof(InvalidSerialException))
            {
                var controller = SessionSettings.ExistsLoginType ? SessionSettings.RetrieveLoginType.ToString() : EntityType.Account.ToString();
                var routeValue = new RouteValueDictionary(new { controller = controller, action = ActionType.Login });
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }

            if (filterContext.Exception.GetType() == typeof(UnauthorizedAccessException) || filterContext.ActionIsEqualsThan(ActionType.ExternalLogin))
            {
                filterContext.Result = new JsonFactory().Failure(typeof(UnauthorizedAccessException), filterContext.MessageException());
            }
        }
    }
}
