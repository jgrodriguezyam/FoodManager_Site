using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodManager.Startup))]
namespace FoodManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RazorConfig.RegisterRazor();
            SimpleInjectorConfig.ResolveSimpleInjector();
        }
    }
}
