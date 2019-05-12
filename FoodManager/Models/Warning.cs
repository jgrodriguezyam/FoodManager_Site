using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Models
{
    public class Warning
    {
        public Warning()
        {
            Id = 0;
            Code = "";
            Name = "";
            Status = false;
            Disease = new Disease();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public Disease Disease { get; set; }
        public int DiseaseId
        {
            get { return Disease.IsNotNull() ? Disease.Id : 0; }
            set
            {
                Disease.Id = value;
                Disease.Name = "OnlyId";
            }
        }
    }
}