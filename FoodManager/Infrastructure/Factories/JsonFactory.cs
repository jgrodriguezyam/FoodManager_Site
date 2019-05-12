using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exceptions.AppSettings;
using FoodManager.Infrastructure.Exceptions.Client;
using FoodManager.Infrastructure.Exceptions.Session;
using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Infrastructure.Factories
{
    public class JsonFactory : Controller
    {
        public JsonResult Success()
        {
            return Json(new { Result = TempDataType.Success.ToString() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success(string message)
        {
            return Json(new { Result = TempDataType.Success.ToString(), Message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success<T>(T model)
        {
            return Json(new { Result = TempDataType.Success.ToString(), Record = model }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success<T>(List<T> models)
        {
            return Json(new { Result = TempDataType.Success.ToString(), Records = models }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Success<T>(List<T> models, int count)
        {
            return Json(new { Result = TempDataType.Success.ToString(), Records = models, Count = count },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult Failure(Type typeException, string message)
        {
            var result = TempDataType.Failure.ToString();

            if (typeException == typeof(PreconditionFailedException)) result = TempDataType.Precondition.ToString();
            if (typeException == typeof(AcceptedException)) result = TempDataType.Accepted.ToString();
            if (typeException == typeof(ExpectationFailedException)) result = TempDataType.LostSession.ToString();
            if (typeException == typeof(SessionNotFoundException)) result = TempDataType.LostSession.ToString();
            if (typeException == typeof(InvalidSerialException)) result = TempDataType.InvalidSerial.ToString();

            return Json(new {Result = result, Message = message}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Failure(ExceptionContext filterContext)
        {
            var type = filterContext.TypeException();
            var message = filterContext.MessageException();
            return Failure(type, message);
        }
    }
}