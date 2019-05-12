namespace FoodManager.Models
{
    public class UserLogin
    {
        public UserLogin()
        {
            UserName = "";
            Password = "";
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}