using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;

namespace FoodManager.Models
{
    public class Reservation
    {
        private Dealer _dealer;

        public Reservation()
        {
            Id = 0;
            Date = "";
            Portion = 0;
            IsPaid = false;
            MealType = new MealType();
            Worker = new Worker();
            Saucer = new Saucer();
            Dealer = new Dealer();
        }

        public int Id { get; set; }
        public string Date { get; set; }
        public decimal Portion { get; set; }
        public bool IsPaid { get; set; }
        public MealType MealType { get; set; }
        public string MealTypeLabel
        {
            get { return EnumResolver.Meal(MealType.GetValue()); }
        }

        public Worker Worker { get; set; }
        public int WorkerId
        {
            get { return Worker.IsNotNull() ? Worker.Id : 0; }
            set
            {
                Worker.Id = value;
                Worker.Code = "OnlyId";
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

        public Dealer Dealer
        {
            get { return _dealer; }
            set { _dealer = value.IsNull() ? new Dealer() : value; }
        }

        public int? DealerId
        {
            get
            {
                if (Dealer.IsNotNull() && Dealer.Id.IsGreaterThanZero()) return Dealer.Id;
                return null;
            }
            set
            {
                Dealer.Id = value.IsNotNull() ? value.GetValue() : 0;
                Dealer.Name = "OnlyId";
            }
        }
    }
}