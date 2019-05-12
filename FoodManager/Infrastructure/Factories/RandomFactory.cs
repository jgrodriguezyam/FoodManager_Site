using System;

namespace FoodManager.Infrastructure.Factories
{
    public class RandomFactory
    {
        public int Day()
        {
            return new Random().Next(1, 28);
        }

        public int Month()
        {
            return new Random().Next(1, 13);
        }

        public int Year()
        {
            return new Random().Next(1882, 1994);
        }

        public static char Letter()
        {
            return (char)('a' + new Random().Next(0, 26));
        }

        public int Number(int maxValue)
        {
            return new Random().Next(1, maxValue);
        }
    }
}