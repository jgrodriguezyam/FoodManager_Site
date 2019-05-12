using FoodManager.Infrastructure.Enums;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Resolvers;
using FoodManager.Models.Reports;

namespace FoodManager.Models
{
    public class Worker : ReservationReportResponse
    {
        public Worker()
        {
            Id = 0;
            Code = "";
            FirstName = "";
            LastName = "";
            Email = "";
            Imss = "";
            Badge = "";
            LimitEnergy = 0;
            Status = false;
            IsReference = false;
            Gender = new GenderType();
            Role = new Role();
            Department = new Department();
            Job = new Job();
            Branch = new Branch();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }
        public string Imss { get; set; }
        public string Badge { get; set; }
        public int LimitEnergy { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set; }
        public GenderType Gender { get; set; }
        public string GenderLabel
        {
            get { return EnumResolver.Gender(Gender.GetValue()); }
        }

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

        public Department Department { get; set; }
        public int DepartmentId
        {
            get { return Department.IsNotNull() ? Department.Id : 0; }
            set
            {
                Department.Id = value;
                Department.Name = "OnlyId";
            }
        }

        public Job Job { get; set; }
        public int JobId
        {
            get { return Job.IsNotNull() ? Job.Id : 0; }
            set
            {
                Job.Id = value;
                Job.Name = "OnlyId";
            }
        }

        public Branch Branch { get; set; }
        public int BranchId
        {
            get { return Branch.IsNotNull() ? Branch.Id : 0; }
            set
            {
                Branch.Id = value;
                Branch.Name = "OnlyId";
            }
        }
    }
}