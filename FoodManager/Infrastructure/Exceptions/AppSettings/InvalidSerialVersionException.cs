using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.AppSettings
{
    [Serializable]
    public class InvalidSerialVersionException : Exception
    {
        public InvalidSerialVersionException()
            : base(ExceptionConstants.InvalidSerialVersion)
        {
        }
    }
}