using System;
using FoodManager.Infrastructure.Constants;

namespace FoodManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base(ExceptionConstants.NotFound)
        {
        }
    }
}