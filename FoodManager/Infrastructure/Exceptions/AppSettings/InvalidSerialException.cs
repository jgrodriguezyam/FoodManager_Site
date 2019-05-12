using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.AppSettings
{
    [Serializable]
    public class InvalidSerialException : Exception
    {
        public InvalidSerialException()
            : base(ExceptionConstants.InvalidSerial)
        {
        }
    }
}