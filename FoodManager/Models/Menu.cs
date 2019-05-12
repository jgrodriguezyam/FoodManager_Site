using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Models
{
    public class Menu
    {
        public Menu()
        {
            Id = 0;
            Comment = "";
            DayWeek = new DayWeekName();
            StartDate = "";
            EndDate = "";
            MaxAmount = 0;
            Status = false;
            MealType = new MealType();
            Dealer =  new Dealer();
            Saucer = new Saucer();
        }

        public int Id { get; set; }
        public string Comment { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int MaxAmount { get; set; }
        public bool Status { get; set; }
        public DayWeekName DayWeek { get; set; }
        public string DayWeekLabel
        {
            get { return EnumResolver.DayWeek(DayWeek.GetValue()); }
        }
        public MealType MealType { get; set; }
        public string MealTypeLabel
        {
            get { return EnumResolver.Meal(MealType.GetValue()); }
        }

        public Dealer Dealer { get; set; }
        public int DealerId
        {
            get { return Dealer.IsNotNull() ? Dealer.Id : 0; }
            set
            {
                Dealer.Id = value;
                Dealer.Name = "OnlyId";
            }
        }

        public Saucer Saucer { get; set; }
        public int SaucerId
        {
            get { return Saucer.IsNotNull() ? Saucer.Id : 0; }
            set
            {
                Saucer.Id = value;
                Saucer.Name = "OnlyId";
            }
        }
    }
}