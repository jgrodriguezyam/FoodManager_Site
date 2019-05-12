using System.Web.Mvc;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public JsonResult Filter(RoleFilter filter)
        {
            var response = _roleService.Filter(filter);
            return new JsonFactory().Success(response.Roles, response.TotalRecords);
        }

    }
}