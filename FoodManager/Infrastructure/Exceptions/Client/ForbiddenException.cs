using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
            : base(ExceptionConstants.Forbidden)
        {
        }
    }
}