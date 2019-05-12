namespace FoodManager.Models
{
    public class Disease
    {
        public Disease()
        {
            Id = 0;
            Code = "";
            Name = "";
            Status = false;
            IsReference = false;
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set; }
    }
}