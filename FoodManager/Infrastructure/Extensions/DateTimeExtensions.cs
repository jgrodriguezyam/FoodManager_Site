using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodManager.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsValidDate(this DateTime date)
        {
            return date > DateTime.MinValue && date < DateTime.MaxValue;
        }

        public static bool IsNotValidDate(this DateTime date)
        {
            return !date.IsValidDate();
        }

        public static string GetTicksNow()
        {
            return DateTime.Now.Ticks.ToString();
        }

        public static DateTime Today()
        {
            return DateTime.Today;
        }

        public static string ConvertToString(this DateTime dateTime)
        {
            return dateTime.ToString("d");
        }

        public static bool IsGreaterThanToday(this DateTime dateTime)
        {
            return dateTime.Date > Today().Date;
        }

        public static bool IsLessThanToday(this DateTime dateTime)
        {
            return dateTime.Date < Today().Date;
        }

        public static bool IsLessThanToday(this List<DateTime> dateTimes)
        {
            return dateTimes.All(dateTime => dateTime.IsLessThanToday());
        }
    }
}