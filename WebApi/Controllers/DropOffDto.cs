namespace WebApi.Controllers
{
    public class DropOffDto
    {
        public string AgentId { get; internal set; }
        public string LockerBankCode { get; internal set; }
        public string OperatorId { get; internal set; }
        public string ParcelConsignmentNumber { get; internal set; }
        public string ResidentId { get; internal set; }
    }
}