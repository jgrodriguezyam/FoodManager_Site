using System.Web.Mvc;
using FoodManager.Infrastructure.RazorView;

namespace FoodManager
{
    public class RazorConfig
    {
        public static void RegisterRazor()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new CSharpRazorViewEngine());
        }
    }
}
