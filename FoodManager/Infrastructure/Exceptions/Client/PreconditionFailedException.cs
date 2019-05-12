using System;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class PreconditionFailedException : Exception
    {
        public PreconditionFailedException()
        {

        }

        public PreconditionFailedException(string message)
            : base(message)
        {

        }
    }
}