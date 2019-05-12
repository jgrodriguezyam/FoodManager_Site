using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ServerNotFoundException : Exception
    {
        public ServerNotFoundException()
            : base(ExceptionConstants.ServerNotFound)
        {
        }
    }
}