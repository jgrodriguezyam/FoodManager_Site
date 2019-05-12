using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Models
{
    public class User
    {
        private Dealer _dealer;

        public User()
        {
            Id = 0;
            Name = "";
            UserName = "";
            NewPassword = "";
            ConfirmPassword = "";
            Status = false;
            IsReference = false;
            Role = new Role();
            Dealer = new Dealer();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set; }

        public Role Role { get; set; }
        public int RoleId
        {
            get { return Role.IsNotNull() ? Role.Id : 0; }
            set
            {
                Role.Id = value;
                Role.Name = "OnlyId";
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

        public string Password
        {
            get { return ConfirmPassword; }
        }
    }
}