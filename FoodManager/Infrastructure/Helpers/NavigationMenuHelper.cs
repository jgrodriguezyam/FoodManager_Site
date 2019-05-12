using System.Web;
using System.Web.Mvc;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Infrastructure.Helpers
{
    public static class NavigationMenuHelper
    {
        public static IHtmlString MenuIsActive(this HtmlHelper helper, NavigationMenu navigationMenu)
        {
            var actionName = helper.ViewContext.RouteData.GetRequiredString("action");
            var controllerName = helper.ViewContext.RouteData.GetRequiredString("controller");
            if (navigationMenu.ToString().IsEquals(NavigationMenu.Catalog.ToString()) && NavigationMenuResolver.Catalog().Exist(controllerName) && actionName != ActionType.Report.ToString())
                return new HtmlString("active");
            if (navigationMenu.ToString().IsEquals(NavigationMenu.Alimentation.ToString()) && NavigationMenuResolver.Alimentation().Exist(controllerName) && actionName != ActionType.Report.ToString())
                return new HtmlString("active");
            if (navigationMenu.ToString().IsEquals(NavigationMenu.Report.ToString()) && NavigationMenuResolver.Report().Exist(controllerName) && actionName == ActionType.Report.ToString())
                return new HtmlString("active");
            if (navigationMenu.ToString().IsEquals(NavigationMenu.Reservation.ToString()) && NavigationMenuResolver.Reservation().Exist(controllerName) && actionName != ActionType.Report.ToString())
                return new HtmlString("active");
            if (navigationMenu.ToString().IsEquals(NavigationMenu.Account.ToString()) && NavigationMenuResolver.Account().Exist(controllerName) && actionName != ActionType.Report.ToString())
                return new HtmlString("active");

            return new HtmlString("");
        }

        public static IHtmlString SubMenuIsActive(this HtmlHelper helper, ActionType action, EntityType entity)
        {
            var actionName = helper.ViewContext.RouteData.GetRequiredString("action");
            var controllerName = helper.ViewContext.RouteData.GetRequiredString("controller");
            var returnActive = (action.ToString().IsEquals(actionName) && entity.ToString().IsEquals(controllerName));
            return new HtmlString(returnActive ? "active" : "");
        }
    }
}