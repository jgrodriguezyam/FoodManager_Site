using System;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class AcceptedException : Exception
    {
        public AcceptedException()
        {

        }

        public AcceptedException(string message)
            : base(message)
        {

        }
    }
}