namespace FoodManager.Models.Filters
{
    public class ReservationDetailFilter : SortingAndPagination
    {
        public ReservationDetailFilter()
        {
            ReservationId = 0;
        }

        public int ReservationId { get; set; }
    }
}