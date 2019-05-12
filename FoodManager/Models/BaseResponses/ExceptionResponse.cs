namespace FoodManager.Models.BaseResponses
{
    public class ExceptionResponse
    {
        public ExceptionResponse()
        {
            Message = "";
        }

        public string Message { get; set; }
    }
}