using System.Web.Mvc;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Controllers
{
    public class SystemController : Controller
    {

        [HttpGet]
        public ActionResult Months()
        {
            var months = new EMonth().ConvertToCollection();
            months.ForEach(month => month.Name = EnumResolver.Month(month.Value));
            return new JsonFactory().Success(months);
        }


    }
}