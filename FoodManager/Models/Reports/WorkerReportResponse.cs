using System.Collections.Generic;

namespace FoodManager.Models.Reports
{
    public class WorkerReportResponse
    {
        public WorkerReportResponse()
        {
            Workers = new List<Worker>();
        }

        public List<Worker> Workers { get; set; }
    }
}