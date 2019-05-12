using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base(ExceptionConstants.BadRequest)
        {
        }
    }
}