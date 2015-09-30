namespace WebApi.Controllers
{
    public class DropOffDto
    {
        public string AgentId { get;  set; }
        public string LockerBankCode { get;  set; }
        public string OperatorId { get;  set; }
        public string ParcelConsignmentNumber { get;  set; }
        public string ResidentId { get;  set; }

        public string LockerId { get; set; }
    }
}