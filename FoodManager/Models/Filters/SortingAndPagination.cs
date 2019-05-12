namespace FoodManager.Models.Filters
{
    public class SortingAndPagination
    {
        public SortingAndPagination()
        {
            StartPage = 0;
            EndPage = 0;
            Sort = "";
            SortBy = "";
        }

        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public string Sort { get; set; }
        public string SortBy { get; set; }
    }
}