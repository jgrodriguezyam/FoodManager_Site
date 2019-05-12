using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Exports;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Factories;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Reports;
using FoodManager.Services.Interfaces;

namespace FoodManager.Controllers
{
    public class SaucerController : Controller
    {
        private readonly ISaucerService _saucerService;
        private readonly ISaucerConfigurationService _saucerConfigurationService;
        private readonly ISaucerMultimediaService _saucerMultimediaService;

        public SaucerController(ISaucerService saucerService, ISaucerConfigurationService saucerConfigurationService, ISaucerMultimediaService saucerMultimediaService)
        {
            _saucerService = saucerService;
            _saucerConfigurationService = saucerConfigurationService;
            _saucerMultimediaService = saucerMultimediaService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(ActionType.Index.ToString());
        }

        [HttpGet]
        public ViewResult New()
        {
            return View(ActionType.New.ToString(), new Saucer());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var saucer = _saucerService.Get(id);
            saucer.SaucerConfigurations = _saucerConfigurationService.OnlyWithSaucerId(id);
            saucer.SaucerMultimedias = _saucerMultimediaService.OnlyWithSaucerId(id);
            return View(ActionType.Edit.ToString(), saucer);
        }

        [HttpGet]
        public ActionResult Report()
        {
            var reportResponse = _saucerService.Report(new SaucerReport());
            return View(reportResponse);
        }

        [HttpGet]
        public JsonResult Filter(SaucerFilter filter)
        {
            var response = _saucerService.Filter(filter);
            return new JsonFactory().Success(response.Saucers, response.TotalRecords);
        }

        [HttpGet]
        public JsonResult NutritionInformation(int id)
        {
            var response =_saucerService.NutritionInformation(id);
            return new JsonFactory().Success(response);
        }

        [HttpGet]
        public FileResult Export(SaucerFilter filter)
        {
            var response = _saucerService.Filter(filter);
            foreach (var saucer in response.Saucers)
            {
                saucer.SaucerConfigurations = _saucerConfigurationService.OnlyWithSaucerId(saucer.Id);
            }

            var csv = new CsvExport();
            csv.ConcatRow(0, "PLATILLO,TIPO,INGREDIENTES,ESTADO");
            csv.ConcatRows(0, "Name,TypeLabel,SaucerConfigurations,Status", response.Saucers);

            var stream = csv.RetrieveFile();
            return new StreamFactory().Csv(stream, "Platillos");
        }

        [HttpPost]
        public ActionResult Create(Saucer request)
        {
            _saucerService.Create(request);

            foreach (var saucerConfiguration in request.SaucerConfigurations)
            {
                saucerConfiguration.SaucerId = request.Id;
                _saucerConfigurationService.Create(saucerConfiguration);
            }

            foreach (var saucerMultimedia in request.SaucerMultimedias)
            {
                _saucerMultimediaService.Create(request.Id, saucerMultimedia.FileBase);
            }
            return RedirectToAction(Request.Form["View"], EntityType.Saucer.ToString());
        }

        [HttpPost]
        public ActionResult Update(Saucer request)
        {
            _saucerService.Update(request);

            if (request.Status)
            {
                var saucerConfigurationsInDataBase = _saucerConfigurationService.OnlyWithSaucerId(request.Id);
                var saucerConfigurationIdsInDataBase = saucerConfigurationsInDataBase.Select(x => x.Id).ToList();
                var saucerConfigurationsByDelete = saucerConfigurationIdsInDataBase.Except(request.SaucerConfigurations.Select(x => x.Id));
                var saucerConfigurationsByUpdate = request.SaucerConfigurations.Where(x => x.Id.IsGreaterThanZero());
                var saucerConfigurationsByCreate = request.SaucerConfigurations.Where(x => x.Id.IsEqualToZero());

                foreach (var saucerConfigurationByDelete in saucerConfigurationsByDelete)
                    _saucerConfigurationService.Delete(saucerConfigurationByDelete);

                foreach (var saucerConfigurationByUpdate in saucerConfigurationsByUpdate)
                    _saucerConfigurationService.Update(saucerConfigurationByUpdate);

                foreach (var saucerConfigurationByCreate in saucerConfigurationsByCreate)
                    _saucerConfigurationService.Create(saucerConfigurationByCreate);


                var saucerMultimediasInDataBase = _saucerMultimediaService.OnlyWithSaucerId(request.Id);
                var saucerMultimediaIdsInDataBase = saucerMultimediasInDataBase.Select(x => x.Id).ToList();
                var saucerMultimediasByDelete = saucerMultimediaIdsInDataBase.Except(request.SaucerMultimedias.Select(x => x.Id));
                var saucerMultimediasByCreate = request.SaucerMultimedias.Where(x => x.Id.IsEqualToZero());

                foreach (var saucerMultimediaByDelete in saucerMultimediasByDelete)
                    _saucerMultimediaService.Delete(saucerMultimediaByDelete);

                foreach (var saucerMultimediaByCreate in saucerMultimediasByCreate)
                    _saucerMultimediaService.Create(request.Id, saucerMultimediaByCreate.FileBase);
            }
            return RedirectToAction(Request.Form["View"], EntityType.Saucer.ToString());
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id, bool status)
        {
            _saucerService.ChangeStatus(id, status);
            return new JsonFactory().Success(status ? MessageConstants.Activate : MessageConstants.Deactivate);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _saucerService.Delete(id);
            return new JsonFactory().Success(MessageConstants.Delete);
        }

    }
}