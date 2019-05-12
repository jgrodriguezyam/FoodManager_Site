using System;
using System.Collections.Generic;
using System.Linq;
using FoodManager.Models.BaseResponses;

namespace FoodManager.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static List<Enumerator> ConvertToCollection(this Enum enumerator)
        {
            var type = enumerator.GetType();
            return Enum.GetNames(type)
                    .Select(name => new Enumerator { Name = name, Value = (int)Enum.Parse(type, name) })
                    .ToList();
        }

        public static int GetValue(this object key)
        {
            var type = key.GetType();
            return (int)Enum.Parse(type, key.ToString());
        }

        public static bool IsEquals(this Enum enumerator1, Enum enumerator2)
        {
            return Equals(enumerator1, enumerator2);
        }

        public static bool IsNotEquals(this Enum enumerator1, Enum enumerator2)
        {
            return !IsEquals(enumerator1, enumerator2);
        }

        public static int RetrieveMaxValue<TEnum>(this TEnum enumerator)
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Max().GetValue();
        }

        public static int RetrieveMinValue<TEnum>(this TEnum enumerator)
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Min().GetValue();
        }
    }
}