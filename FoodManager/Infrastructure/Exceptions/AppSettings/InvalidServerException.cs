using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.AppSettings
{
    [Serializable]
    public class InvalidServerException : Exception
    {
        public InvalidServerException()
            : base(ExceptionConstants.InvalidServer)
        {
        }
    }
}