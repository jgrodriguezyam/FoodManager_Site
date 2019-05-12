using FoodManager.Infrastructure.SimpleInjector;
using SimpleInjector;

namespace FoodManager
{
    public static class SimpleInjectorConfig
    {
        public static void ResolveSimpleInjector()
        {
            var container = new Container();
            SimpleInjectorModule.SetContainer(container);
            SimpleInjectorModule.LoadServices();
            SimpleInjectorModule.VerifyContainer();

            SimpleInjectorModule.SetFilters();
            SimpleInjectorModule.LoadFilters();
        }
    }
}