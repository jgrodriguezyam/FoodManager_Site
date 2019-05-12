namespace FoodManager.Models
{
    public class Role
    {
        public Role()
        {
            Id = 0;
            Name = "";
            Status = false;
            IsReference = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set; }
    }
}