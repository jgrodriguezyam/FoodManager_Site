using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Infrastructure.Resolvers
{
    public static class EnumResolver
    {
        public static string Login(int loginType)
        {
            if (loginType.IsEqualTo(LoginType.User.GetValue()))
                return DisplayConstants.LoginUser;
            if (loginType.IsEqualTo(LoginType.Worker.GetValue()))
                return DisplayConstants.LoginWorker;

            return DisplayConstants.LoginWithoutAccount;
        }

        public static string Saucer(int saucerType)
        {
            if (saucerType.IsEqualTo(SaucerType.Main.GetValue()))
                return DisplayConstants.SaucerMain;
            if (saucerType.IsEqualTo(SaucerType.Garrison.GetValue()))
                return DisplayConstants.SaucerGarrison;
            if (saucerType.IsEqualTo(SaucerType.Drink.GetValue()))
                return DisplayConstants.SaucerDrink;
            if (saucerType.IsEqualTo(SaucerType.Dessert.GetValue()))
                return DisplayConstants.SaucerDessert;

            return DisplayConstants.WithoutType;
        }

        public static string SaucerIcon(int saucerType)
        {
            if (saucerType.IsEqualTo(SaucerType.Main.GetValue()))
                return DisplayConstants.SaucerIconMain;
            if (saucerType.IsEqualTo(SaucerType.Garrison.GetValue()))
                return DisplayConstants.SaucerIconGarrison;
            if (saucerType.IsEqualTo(SaucerType.Drink.GetValue()))
                return DisplayConstants.SaucerIconDrink;
            if (saucerType.IsEqualTo(SaucerType.Dessert.GetValue()))
                return DisplayConstants.SaucerIconDessert;

            return DisplayConstants.SaucerIconWithoutType;
        }

        public static string Gender(int genderType)
        {
            if (genderType.IsEqualTo(GenderType.Male.GetValue()))
                return DisplayConstants.GenderMale;
            if (genderType.IsEqualTo(GenderType.Female.GetValue()))
                return DisplayConstants.GenderFemale;
            return "";
        }

        public static string Meal(int mealType)
        {
            if (mealType.IsEqualTo(MealType.Breakfast.GetValue()))
                return DisplayConstants.MealBreakfast;
            if (mealType.IsEqualTo(MealType.Lunch.GetValue()))
                return DisplayConstants.MealLunch;
            if (mealType.IsEqualTo(MealType.Dinner.GetValue()))
                return DisplayConstants.MealDinner;
            if (mealType.IsEqualTo(MealType.Dinner.GetValue()))
                return DisplayConstants.MealDinner;
            if (mealType.IsEqualTo(MealType.Collation.GetValue()))
                return DisplayConstants.MealCollation;

            return DisplayConstants.WithoutType;
        }

        public static string DayWeek(int dayWeeekName)
        {
            if (dayWeeekName.IsEqualTo(DayWeekName.Sunday.GetValue()))
                return DisplayConstants.DayWeekSunday;
            if (dayWeeekName.IsEqualTo(DayWeekName.Monday.GetValue()))
                return DisplayConstants.DayWeekMonday;
            if (dayWeeekName.IsEqualTo(DayWeekName.Tuesday.GetValue()))
                return DisplayConstants.DayWeekTuesday;
            if (dayWeeekName.IsEqualTo(DayWeekName.Wednesday.GetValue()))
                return DisplayConstants.DayWeekWednesday;
            if (dayWeeekName.IsEqualTo(DayWeekName.Thursday.GetValue()))
                return DisplayConstants.DayWeekThursday;
            if (dayWeeekName.IsEqualTo(DayWeekName.Friday.GetValue()))
                return DisplayConstants.DayWeekFriday;
            if (dayWeeekName.IsEqualTo(DayWeekName.Saturday.GetValue()))
                return DisplayConstants.DayWeekSaturday;
            if (dayWeeekName.IsEqualTo(DayWeekName.All.GetValue()))
                return DisplayConstants.DayWeekAll;

            return DisplayConstants.DayWeekWithoutType;
        }

        public static string Month(int month)
        {
            if (month.IsEqualTo(EMonth.January.GetValue()))
                return DisplayConstants.MonthJanuary;
            if (month.IsEqualTo(EMonth.February.GetValue()))
                return DisplayConstants.MonthFebruary;
            if (month.IsEqualTo(EMonth.March.GetValue()))
                return DisplayConstants.MonthMarch;
            if (month.IsEqualTo(EMonth.April.GetValue()))
                return DisplayConstants.MonthApril;
            if (month.IsEqualTo(EMonth.May.GetValue()))
                return DisplayConstants.MonthMay;
            if (month.IsEqualTo(EMonth.June.GetValue()))
                return DisplayConstants.MonthJune;
            if (month.IsEqualTo(EMonth.July.GetValue()))
                return DisplayConstants.MonthJuly;
            if (month.IsEqualTo(EMonth.August.GetValue()))
                return DisplayConstants.MonthAugust;
            if (month.IsEqualTo(EMonth.September.GetValue()))
                return DisplayConstants.MonthSeptember;
            if (month.IsEqualTo(EMonth.October.GetValue()))
                return DisplayConstants.MonthOctober;
            if (month.IsEqualTo(EMonth.November.GetValue()))
                return DisplayConstants.MonthNovember;
            if (month.IsEqualTo(EMonth.Dicember.GetValue()))
                return DisplayConstants.MonthDicember;
            return "";
        }

        public static string RecurrenceFilter(int recurrenceFilterType)
        {
            if (recurrenceFilterType.IsEqualTo(RecurrenceType.Daily.GetValue()))
                return DisplayConstants.RecurrrenceDaily;
            if (recurrenceFilterType.IsEqualTo(RecurrenceType.Weekly.GetValue()))
                return DisplayConstants.RecurrrenceWeekly;
            if (recurrenceFilterType.IsEqualTo(RecurrenceType.Monthly.GetValue()))
                return DisplayConstants.RecurrrenceMonthly;

            return DisplayConstants.WithoutType;
        }

        public static string Unit(int unitType)
        {
            if (unitType.IsEqualTo(UnitType.Grams.GetValue()))
                return DisplayConstants.UnitGrams;
            if (unitType.IsEqualTo(UnitType.Milliliter.GetValue()))
                return DisplayConstants.UnitMilliliter;

            return DisplayConstants.UnitWithoutType;
        }

        public static string Status(bool status)
        {
            return status ? DisplayConstants.StatusActive : DisplayConstants.StatusInactive;
        }
    }
}