using System.Web.Mvc;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class SaucerConfigurationController : Controller
    {
        private readonly ISaucerConfigurationService _saucerConfigurationService;

        public SaucerConfigurationController(ISaucerConfigurationService saucerConfigurationService)
        {
            _saucerConfigurationService = saucerConfigurationService;
        }

        [HttpGet]
        public JsonResult Filter(SaucerConfigurationFilter filter)
        {
            var response = _saucerConfigurationService.Filter(filter);
            return new JsonFactory().Success(response.SaucerConfigurations, response.TotalRecords);
        }

    }
}