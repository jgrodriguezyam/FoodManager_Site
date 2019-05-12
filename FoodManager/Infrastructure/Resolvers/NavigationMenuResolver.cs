using System.Collections.Generic;
using FoodManager.Infrastructure.Enums;

namespace FoodManager.Infrastructure.Resolvers
{
    public static class NavigationMenuResolver
    {
        public static List<string> Catalog()
        {
            return new List<string>
            {
                EntityType.Region.ToString(),
                EntityType.Company.ToString(),
                EntityType.Branch.ToString(),
                EntityType.Department.ToString(),
                EntityType.Job.ToString(),
                EntityType.Disease.ToString(),
                EntityType.Dealer.ToString(),
                EntityType.User.ToString(),
                EntityType.Worker.ToString()
            };
        }

        public static List<string> Alimentation()
        {
            return new List<string>
            {
                EntityType.Tip.ToString(),
                EntityType.Warning.ToString(),
                EntityType.IngredientGroup.ToString(),
                EntityType.Ingredient.ToString(),
                EntityType.Saucer.ToString(),
                EntityType.Menu.ToString()
            };
        }

        public static List<string> Report()
        {
            return new List<string>
            {
                EntityType.Reservation.ToString(),
                EntityType.Saucer.ToString(),
                EntityType.Worker.ToString()
            };
        }

        public static List<string> Reservation()
        {
            return new List<string>
            {
                EntityType.Reservation.ToString()
            };
        }

        public static List<string> Account()
        {
            return new List<string>
            {
                EntityType.Account.ToString()
            };
        }

    }
}