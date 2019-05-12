using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Models
{
    public class ReservationDetail
    {
        public ReservationDetail()
        {
            Id = 0;
            Portion = 0;
            Reservation = new Reservation();
            Ingredient = new Ingredient();
        }

        public int Id { get; set; }
        public decimal Portion { get; set; }

        public Reservation Reservation { get; set; }
        public int ReservationId
        {
            get { return Reservation.IsNotNull() ? Reservation.Id : 0; }
            set
            {
                Reservation.Id = value;
            }
        }

        public Ingredient Ingredient { get; set; }
        public int IngredientId
        {
            get { return Ingredient.IsNotNull() ? Ingredient.Id : 0; }
            set
            {
                Ingredient.Id = value;
                Ingredient.Name = "OnlyId";
            }
        }
    }
}