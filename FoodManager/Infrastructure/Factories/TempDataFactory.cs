using System;
using System.Web.Mvc;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exceptions.AppSettings;
using FoodManager.Infrastructure.Exceptions.Session;
using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Infrastructure.Factories
{
    public class TempDataFactory : Controller
    {
        #region Create

        public void CreateFailure(Type typeException,ControllerBase controller, string message)
        {
            var tempData = TempDataType.Failure.ToString();

            if (typeException == typeof(InvalidSerialException)) tempData = TempDataType.InvalidSerial.ToString();
            if (typeException == typeof(SessionNotFoundException)) tempData = TempDataType.LostSession.ToString();

            controller.TempData[tempData] = message;
        }

        public void CreateFailure(ExceptionContext filterContext)
        {
            var type = filterContext.TypeException();
            var controller = filterContext.ControllerBase();
            var message = filterContext.MessageException();
            CreateFailure(type, controller, message);
        }

        public void CreateFailure(ControllerBase controller, string message)
        {
            controller.TempData[TempDataType.Failure.ToString()] = message;
        }

        public void CreateSuccess(ControllerBase controller, string message)
        {
            controller.TempData[TempDataType.Success.ToString()] = message;
        }

        public void CreateInformation(ControllerBase controller, string message)
        {
            controller.TempData[TempDataType.Information.ToString()] = message;
        }

        public void CreateWarning(ControllerBase controller, string message)
        {
            controller.TempData[TempDataType.Warning.ToString()] = message;
        }

        #endregion

        #region Remove

        public void RemoveFailure(ControllerBase controller)
        {
            controller.TempData[TempDataType.Failure.ToString()] = null;
        }

        public void RemoveSuccess(ControllerBase controller)
        {
            controller.TempData[TempDataType.Success.ToString()] = null;
        }

        public void RemoveInformation(ControllerBase controller)
        {
            controller.TempData[TempDataType.Information.ToString()] = null;
        }

        public void RemoveWarning(ControllerBase controller)
        {
            controller.TempData[TempDataType.Warning.ToString()] = null;
        }

        public void RemoveLostSession(ControllerBase controller)
        {
            controller.TempData[TempDataType.LostSession.ToString()] = null;
        }

        public void RemoveInvalidSerial(ControllerBase controller)
        {
            controller.TempData[TempDataType.InvalidSerial.ToString()] = null;
        }

        #endregion
    }
}