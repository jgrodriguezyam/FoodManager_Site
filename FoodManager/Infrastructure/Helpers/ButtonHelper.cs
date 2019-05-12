using System;
using System.Web;
using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Infrastructure.Helpers
{
    public static class ButtonHelper
    {
        public static IHtmlString ButtonsForm(this HtmlHelper helper)
        {
            //var actionName = helper.ViewContext.RouteData.GetRequiredString("action");
            var controllerName = helper.ViewContext.RouteData.GetRequiredString("controller");
            //var displayText = ActionDictionary.DisplayToActionType[actionName];
            var displayText = DisplayConstants.Save;
            var uriCancel = String.Format("{0}{1}/Index", RootResolver.Resolver, controllerName);

            var htmlString = string.Empty;
            htmlString += "<div class='btn-success btn-group pull-left dropdown margin-bottom-15'>";
            htmlString += "<button id='Create' type='submit' class='btn btn-success' data-redirectto='Index'>" + displayText + "</button>";
            htmlString += "<button type='button' class='btn btn-success dropdown-toggle' data-toggle='dropdown'>";
            htmlString += "<span class='caret'></span>";
            htmlString += "</button>";
            htmlString += "<ul class='dropdown-menu left'>";
            htmlString += "<li> <a class='iconPointer submitBtn' data-redirectto='New'>" + displayText + " y nuevo</a></li>";
            htmlString += "</ul>";
            htmlString += "</div>";
            htmlString += "<input type='hidden' id='View' name='View' value='' />";
            htmlString += "<a class='btn btn-default margin-left-10' href='" + uriCancel + "'>Cancelar</a>";

            return new HtmlString(htmlString);
        }

        public static IHtmlString ButtonSave(this HtmlHelper helper)
        {
            var htmlString = string.Empty;
            htmlString += "<div class='col-lg-1 container-right'>";
            htmlString += "<button type='button' class='Save btn btn-success btn-block btnSave'>" + DisplayConstants.Save + "</button>";
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }
    }
}