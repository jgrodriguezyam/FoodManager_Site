using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.InternetConnectivity
{
    [Serializable]
    public class InternetConnectivityException : Exception
    {
        public InternetConnectivityException()
            : base(ExceptionConstants.InternetConnectivity)
        {
        }
    }
}