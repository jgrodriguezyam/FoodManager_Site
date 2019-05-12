using System;
using System.Collections.Generic;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Constants;
using FoodManager.Models;
using FoodManager.Models.Filters;
using FoodManager.Models.Pages;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class MenuService : IMenuService
    {
        public Menu Get(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Menu, id);
            return Request.Get<Menu>(uri);
        }

        public MenuPage Filter(MenuFilter request)
        {
            var uri = String.Format(PluralEntityConstants.Menu);
            return Request.Filter<MenuPage>(uri, request);
        }

        public List<Menu> OnlyStatusActivated()
        {
            var request = new MenuFilter { OnlyStatusActivated = true };
            return Filter(request).Menus;
        }

        public void Create(Menu request)
        {
            request.MaxAmount = 1;
            var uri = String.Format(PluralEntityConstants.Menu);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(Menu request)
        {
            request.MaxAmount = 1;
            var uri = String.Format(PluralEntityConstants.Menu);
            Request.Put(uri, request);
        }

        public void Delete(int id)
        {
            var uri = String.Format("{0}/{1}", PluralEntityConstants.Menu, id);
            Request.Delete(uri);
        }

        public void ChangeStatus(int id, bool status)
        {
            var uri = String.Format("{0}/{1}/status/{2}", PluralEntityConstants.Menu, id, status);
            Request.Put(uri);
        }
    }
}