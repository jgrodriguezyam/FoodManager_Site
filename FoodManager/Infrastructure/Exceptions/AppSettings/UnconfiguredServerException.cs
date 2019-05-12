using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.AppSettings
{
    [Serializable]
    public class UnconfiguredServerException : Exception
    {
        public UnconfiguredServerException()
            : base(ExceptionConstants.UnconfiguredServer)
        {
        }
    }
}