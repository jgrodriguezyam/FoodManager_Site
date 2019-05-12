namespace FoodManager.Infrastructure.Extensions
{
    public static class DecimalExtensions
    {

        public static decimal RoundDecimal(this decimal value)
        {
            return System.Math.Round(value, 2);
        }

    }
}
