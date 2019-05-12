using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException(): base(ExceptionConstants.Conflict)
        {
        }

        public ConflictException(string message)
            : base(message)
        {

        }
    }

}