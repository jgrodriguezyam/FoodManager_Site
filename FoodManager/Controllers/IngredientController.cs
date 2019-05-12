using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Infrastructure.Resolvers;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Ingredient());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ingredient = _ingredientService.Get(id);
            return View(ActionType.Edit.ToString(), ingredient);
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var ingredient = _ingredientService.Get(id);
            return new JsonFactory().Success(ingredient);
        }

        [HttpGet]
        public JsonResult Filter(IngredientFilter filter)
        {
            var response = _ingredientService.Filter(filter);
            return new JsonFactory().Success(response.Ingredients, response.TotalRecords);
        }

        [HttpGet]
        public JsonResult GetUnits()
        {
            var units = new UnitType().ConvertToCollection();
            foreach (var unit in units)
                unit.Name = EnumResolver.Unit(unit.Value);
            return new JsonFactory().Success(units, units.Count);
        }

        [HttpGet]
        public FileResult Export(IngredientFilter filter)
        {
            var response = _ingredientService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "INGREDIENTE,GRUPO,UNIDAD,PESO NETO,ENERGÍA,PROTEÍNAS,CARBOHIDRATOS,AZÚCAR,LÍPIDOS,SODIO,ESTADO");
            csv.ConcatRows(0, "Name,IngredientGroup,UnitLabel,NetWeight,Energy,Protein,Carbohydrate,Sugar,Lipid,Sodium,Status", response.Ingredients);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Ingredientes");
        }

        [HttpPost]
        public ActionResult Create(Ingredient request)
        {
            _ingredientService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.Ingredient.ToString());
        }

        [HttpPost]
        public ActionResult Update(Ingredient request)
        {
            _ingredientService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.Ingredient.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _ingredientService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _ingredientService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}