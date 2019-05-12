namespace FoodManager.Models.BaseResponses
{
    public class SuccessResponse
    {
        public SuccessResponse()
        {
            IsSuccess = false;
        }

        public bool IsSuccess { get; set; }
    }
}