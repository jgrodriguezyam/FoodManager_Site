using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class InternalServerException : Exception
    {
        public InternalServerException()
            : base(ExceptionConstants.InvalidServer)
        {
        }
    }
}