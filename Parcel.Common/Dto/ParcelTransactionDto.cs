using Common.Values;
using System;

namespace Tz.Parcel.Common.Dto
{
    public class ParcelTransactionDto:Base
    {
        public Guid ParcelTransactionId { get; set; }

        public Guid ParcelId { get; set; }

        public TransactionState TransactionState { get; set; }

        public Guid DropOffAgentId { get; set; }

        public DateTime DropoffTime { get; set; }
        public Guid LockerId { get; set; }
    }
}