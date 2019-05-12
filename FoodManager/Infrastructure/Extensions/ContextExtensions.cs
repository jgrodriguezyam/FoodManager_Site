using System;
using System.Linq;
using System.Web.Mvc;
using FoodManager.Infrastructure.Dictionaries;
using FoodManager.Infrastructure.Enums;

namespace FoodManager.Infrastructure.Extensions
{
    public static class ContextExtensions
    {
        #region ActionExecutingContext

        public static string ActionName(this ActionExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["action"].ToString();
        }

        public static string ControllerName(this ActionExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["controller"].ToString();
        }

        public static object ContextModel(this ActionExecutingContext filterContext)
        {
            return filterContext.ActionParameters["request"];
        }

        public static bool ControllerIsEqualsThan(this ActionExecutingContext filterContext, EntityType entityType)
        {
            return filterContext.ControllerName().IsEquals(entityType.ToString());
        }

        public static bool ActionIsEqualsThan(this ActionExecutingContext filterContext, ActionType actionType)
        {
            return filterContext.ActionName().IsEquals(actionType.ToString());
        }

        public static bool IsEqualsToAccountOrLogin(this ActionExecutingContext filterContext)
        {
            return filterContext.ControllerIsEqualsThan(EntityType.Account) || filterContext.ActionIsEqualsThan(ActionType.Login) || filterContext.ActionIsEqualsThan(ActionType.ExternalLogin);
        }

        public static bool IsNotEqualsToAccountOrLogin(this ActionExecutingContext filterContext)
        {
            return !IsEqualsToAccountOrLogin(filterContext);
        }

        #endregion

        #region ResultExecutingContext

        public static string ActionName(this ResultExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["action"].ToString();
        }

        public static string ControllerName(this ResultExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["controller"].ToString();
        }

        public static object ContextModel(this ResultExecutingContext filterContext)
        {
            return filterContext.Controller.ViewData.Model;
        }

        public static bool ControllerIsEqualsThan(this ResultExecutingContext filterContext, EntityType entityType)
        {
            return filterContext.ControllerName().IsEquals(entityType.ToString());
        }

        public static bool ActionIsEqualsThan(this ResultExecutingContext filterContext, ActionType actionType)
        {
            return filterContext.ActionName().IsEquals(actionType.ToString());
        }

        public static bool ControllerIsNotEqualsThan(this ResultExecutingContext filterContext, EntityType entityType)
        {
            return !filterContext.ControllerIsEqualsThan(entityType);
        }

        public static bool ActionIsNotEqualsThan(this ResultExecutingContext filterContext, ActionType actionType)
        {
            return !filterContext.ActionIsEqualsThan(actionType);
        }

        #endregion

        #region ExceptionContext

        public static string ActionName(this ExceptionContext filterContext)
        {
            return filterContext.RouteData.Values["action"].ToString();
        }

        public static string ControllerName(this ExceptionContext filterContext)
        {
            return filterContext.RouteData.Values["controller"].ToString();
        }

        public static int IdToRequest(this ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.UrlReferrer.Segments.LastOrDefault().ConvertToint();
        }

        public static bool ControllerIsEqualsThan(this ExceptionContext filterContext, EntityType entityType)
        {
            return filterContext.ControllerName().IsEquals(entityType.ToString());
        }

        public static bool ActionIsEqualsThan(this ExceptionContext filterContext, ActionType actionType)
        {
            return filterContext.ActionName().IsEquals(actionType.ToString());
        }

        public static bool ControllerIsNotEqualsThan(this ExceptionContext filterContext, EntityType entityType)
        {
            return !filterContext.ControllerIsEqualsThan(entityType);
        }

        public static string MessageException(this ExceptionContext filterContext)
        {
            return filterContext.Exception.Message;
        }

        public static Type TypeException(this ExceptionContext filterContext)
        {
            return filterContext.Exception.GetType();
        }

        public static bool IsAjaxRequest(this ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.IsAjaxRequest();
        }

        public static ControllerBase ControllerBase(this ExceptionContext filterContext)
        {
            return filterContext.Controller;
        }

        public static object DeserializeContext(this ExceptionContext filterContext, string contextModel)
        {
            var controllerName = filterContext.ControllerName();
            var typeArgument = ModelDictionary.ModelToEntityType[controllerName];
            var methodType = typeof (StringExtensions).GetMethod("Deserialize");
            var genericMethod = methodType.MakeGenericMethod(new[] {typeArgument});
            return genericMethod.Invoke(typeof(ContextExtensions), new object[] { contextModel });
        }

        #endregion
    }
}