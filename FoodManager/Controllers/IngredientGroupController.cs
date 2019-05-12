using System;
using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class IngredientGroupController : Controller
    {
        private readonly IIngredientGroupService _ingredientGroupService;
        private readonly IIngredientService _ingredientService;

        public IngredientGroupController(IIngredientGroupService ingredientGroupService, IIngredientService ingredientService)
        {
            _ingredientGroupService = ingredientGroupService;
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
            return View(ActionType.New.ToString(), new IngredientGroup());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var response = _ingredientGroupService.Get(id);
            return View(ActionType.Edit.ToString(), response);
        }

        [HttpGet]
        public JsonResult Filter(IngredientGroupFilter filter)
        {
            var response = _ingredientGroupService.Filter(filter);
            return new JsonFactory().Success(response.IngredientGroups, response.TotalRecords);
        }

        [HttpGet]
        public FileResult Export(IngredientGroupFilter filter)
        {
            var responseIngredientGroup = _ingredientGroupService.Filter(filter);

            var csv = new CsvExport();
            csv.ConcatRow(0, "COLOR,GRUPO DE INGREDIENTE,INGREDIENTES,ESTADO");
            foreach (var ingredientGroup in responseIngredientGroup.IngredientGroups)
            {
                var responseIngredient = _ingredientService.Filter(new IngredientFilter { IngredientGroupId = ingredientGroup .Id, OnlyStatusActivated = true});
                var rowIngredientGroup = String.Format("{0},{1},,{2}", ingredientGroup.Color, ingredientGroup.Name, ingredientGroup.Status);
                csv.ConcatRow(0, rowIngredientGroup);
                foreach (var ingredient in responseIngredient.Ingredients)
                {
                    var rowIngredient = String.Format(",,{0},{1}", ingredient.Name, ingredient.Status);
                    csv.ConcatRow(0, rowIngredient);
                }
            }

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Grupo de ingredientes");
        }

        [HttpPost]
        public ActionResult Create(IngredientGroup request)
        {
            _ingredientGroupService.Create(request);
            return RedirectToAction(Request.Form["View"], EntityType.IngredientGroup.ToString());
        }

        [HttpPost]
        public ActionResult Update(IngredientGroup request)
        {
            _ingredientGroupService.Update(request);
            return RedirectToAction(Request.Form["View"], EntityType.IngredientGroup.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _ingredientGroupService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _ingredientGroupService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}