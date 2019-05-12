using System;
using FoodManager.Infrastructure.Client;
using FoodManager.Infrastructure.Settings;
using FoodManager.Services.Interfaces;

namespace FoodManager.Services
{
    public class AccountService : IAccountService
    {
        public void IsAlive()
        {
            SessionSettings.AssignAllSessions();
            const string uri = "alive/";
            Request.IsAlive(uri);
        }
    }
}