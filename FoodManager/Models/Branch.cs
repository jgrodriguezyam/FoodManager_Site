using System.Collections.Generic;
using System.Linq;
using FoodManager.Infrastructure.Extensions;

namespace FoodManager.Models
{
    public class Branch
    {
        public Branch()
        {
            Id = 0;
            Code = "";
            Name = "";
            Status = false;
            IsReference = false;
            Dealers = new List<Dealer>();
            Region = new Region();
            Company = new Company();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public bool IsReference { get; set; }
        public List<Dealer> Dealers { get; set; }

        public List<int> DealerIds
        {
            set { Dealers = value.Select(dealerId => new Dealer {Id = dealerId, Name = "OnlyId"}).ToList(); }
            get { return Dealers.Select(dealer => dealer.Id).ToList(); }
        }

        public Company Company { get; set; }
        public int CompanyId
        {
            get { return Company.IsNotNull() ? Company.Id : 0; }
            set
            {
                Company.Id = value;
                Company.Name = "OnlyId";
            }
        }

        public Region Region { get; set; }
        public int RegionId
        {
            get { return Region.IsNotNull() ? Region.Id : 0; }
            set
            {
                Region.Id = value;
                Region.Name = "OnlyId";
            }
        }
    }
}