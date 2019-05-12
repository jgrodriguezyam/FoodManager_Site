using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Session
{
    [Serializable]
    public class SessionNotFoundException : Exception
    {
        public SessionNotFoundException()
            : base(ExceptionConstants.SessionNotFound)
        {
        }
    }
}