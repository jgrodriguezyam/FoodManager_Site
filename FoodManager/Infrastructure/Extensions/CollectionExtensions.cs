using System.Collections.Generic;
using System.Linq;

namespace FoodManager.Infrastructure.Extensions
{
    public static class CollectionExtensions
    {
        public static bool Exist(this List<string> values, string valueToCompare)
        {
            return values.Any(value => value.Equals(valueToCompare));
        }

        public static bool Exist(this List<int> values, int valueToCompare)
        {
            return values.Any(value => value.Equals(valueToCompare));
        }

        public static bool NotExist(this List<int> values, int valueToCompare)
        {
            return !Exist(values, valueToCompare);
        }

        public static string ConvertToString(this IEnumerable<int> values)
        {
            return string.Join(",", values);
        }
    }
}


