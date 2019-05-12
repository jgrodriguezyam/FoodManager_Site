using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class MethodNotAllowedException:Exception
    {
        public MethodNotAllowedException()
            : base(ExceptionConstants.MethodNotAllowed)
        {
            
        }
    }
}