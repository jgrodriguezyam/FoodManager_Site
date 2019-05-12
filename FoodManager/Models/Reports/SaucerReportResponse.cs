using System.Collections.Generic;

namespace FoodManager.Models.Reports
{
    public class SaucerReportResponse
    {
        public SaucerReportResponse()
        {
            Main = new List<Main>();
            Garrison = new List<Garrison>();
        }

        public List<Main> Main { get; set; }
        public List<Garrison> Garrison { get; set; }
    }
}