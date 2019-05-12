using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
            : base(ExceptionConstants.Unauthorized)
        {
        }
    }
}