namespace FoodManager.Models.BaseResponses
{
    public class UserLoginResponse
    {
        public UserLoginResponse()
        {
            UserId = 0;
            PublicKey = "";
        }

        public int UserId { get; set; }
        public int? DealerId { get; set; }
        public string PublicKey { get; set; }
    }
}