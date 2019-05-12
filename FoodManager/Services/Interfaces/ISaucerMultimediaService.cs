using System.Collections.Generic;
using System.Web;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;

namespace FoodManager.Services.Interfaces
{
    public interface ISaucerMultimediaService
    {
        SaucerMultimedia Get(int id);
        SaucerMultimediaPage Filter(SaucerMultimediaFilter request);
        List<SaucerMultimedia> OnlyStatusActivated();
        List<SaucerMultimedia> OnlyWithSaucerId(int saucerId);
        void Create(int saucerId, HttpPostedFileBase multimedia);
        void Delete(int id);
        void ChangeStatus(int id, bool status);
    }
}