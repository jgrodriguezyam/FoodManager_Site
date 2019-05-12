namespace FoodManager.Models.BaseResponses
{
    public class WorkerLoginResponse
    {
        public WorkerLoginResponse()
        {
            WorkerId = 0;
            FullName = "";
            PublicKey = "";
        }

        public int WorkerId { get; set; }
        public string FullName { get; set; }
        public string PublicKey { get; set; }
    }
}