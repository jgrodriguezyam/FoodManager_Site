using System.Web.Optimization;
using FoodManager.Infrastructure.Bundles;

namespace FoodManager
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundleModule.RegisterBundles(bundles);
            StyleBundleModule.RegisterBundles(bundles);
            //BundleTable.EnableOptimizations = true;
        }
    }
}
