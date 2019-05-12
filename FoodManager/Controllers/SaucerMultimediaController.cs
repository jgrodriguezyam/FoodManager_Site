using System.Web.Mvc;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class SaucerMultimediaController : Controller
    {
        private readonly ISaucerMultimediaService _saucerMultimeddiaService;

        public SaucerMultimediaController(ISaucerMultimediaService saucerMultimeddiaService)
        {
            _saucerMultimeddiaService = saucerMultimeddiaService;
        }
        
        [HttpGet]
        public JsonResult Filter(SaucerMultimediaFilter filter)
        {
            var response = _saucerMultimeddiaService.Filter(filter);
            return new JsonFactory().Success(response.SaucerMultimedias, response.TotalRecords);
        }

    }
}