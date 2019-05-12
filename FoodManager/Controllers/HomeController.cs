using System.Web.Mvc;
using FoodManager.Infrastructure.Settings;

namespace FoodManager.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SessionSettings.AssignAllSessions();
            return View("Index");
        }
    }
}