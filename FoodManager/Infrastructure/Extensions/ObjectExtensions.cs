using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace FoodManager.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object @object)
        {
            return @object == null;
        }

        public static bool IsNotNull(this object @object)
        {
            return !IsNull(@object);
        }

        public static bool IsNotEmpty(this IEnumerable<object> objects)
        {
            return objects != null && objects.Any();
        }

        public static bool IsEmpty(this IEnumerable<object> objects)
        {
            return !IsNotEmpty(objects);
        }

        public static Dictionary<string, string> ConvertToDictionary(this object @object)
        {
            if (@object.IsNull())
                return null;

            var dictionary = (from x in @object.GetType().GetProperties() select x).ToDictionary(x => x.Name,
                x => (x.GetGetMethod().Invoke(@object, null) == null ? "" : x.GetGetMethod().Invoke(@object, null).ToString()));
            return dictionary;
        }

        public static T ExtractProperty<T>(this object @object, string property)
        {
            return (T)@object.GetType().GetProperty(property).GetValue(@object, null);
        }

        public static Object ExtractProperty(this object @object, string property)
        {
            return @object.GetType().GetProperty(property).GetValue(@object, null);
        }

        public static string ExtractName(this object @object)
        {
            var id = @object.ExtractProperty<int>("Id");
            return id.IsGreaterThanZero() ? @object.ExtractProperty("Name").ToString() : "-";
        }

        public static string ExtractNames(this object @object)
        {
            var names = String.Empty;
            var list = @object as IList;
            if (list.IsNotNull())
            {
                foreach (var element in list)
                {
                    var name = element.ExtractName();
                    names += String.Format(" [{0}] ", name);
                }
            }
            return names;
        }

        public static string ExtractPaths(this object @object)
        {
            var paths = String.Empty;
            var multimedias = @object as IList;
            if (multimedias.IsNotNull())
            {
                foreach (var multimedia in multimedias)
                {
                    var path = multimedia.ExtractProperty("Path").ToString();
                    paths += String.Format(" [{0}] ", path);
                }
            }
            return paths;
        }

        public static string ExtractTotalAmounts(this object @object)
        {
            var totalAmounts = String.Empty;
            var saucerConfigurations = @object as IList;
            if (saucerConfigurations.IsNotNull())
            {
                foreach (var saucerConfiguration in saucerConfigurations)
                {
                    var ingredient = saucerConfiguration.ExtractProperty("Ingredient");
                    var name = ingredient.ExtractName();
                    totalAmounts += String.Format(" [{0}] ", name);
                }
            }
            return totalAmounts;
        }

        public static Object Serialize(this object @object)
        {
            return new JavaScriptSerializer().Serialize(@object);
        }
    }
}