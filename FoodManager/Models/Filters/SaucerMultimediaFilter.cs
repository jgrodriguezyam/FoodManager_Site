namespace FoodManager.Models.Filters
{
    public class SaucerMultimediaFilter : SortingAndPagination
    {
        public SaucerMultimediaFilter()
        {
            SaucerId = 0;
            SaucerIds = "";
            OnlyStatusActivated = false;
            OnlyStatusDeactivated = false;
        }

        public int SaucerId { get; set; }
        public string SaucerIds { get; set; }
        public bool OnlyStatusActivated { get; set; }
        public bool OnlyStatusDeactivated { get; set; }
    }
}