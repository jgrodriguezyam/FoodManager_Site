using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ExpectationFailedException:Exception
    {
        public ExpectationFailedException()
            : base(ExceptionConstants.ExpectationFailed)
        {
            
        }
    }
}