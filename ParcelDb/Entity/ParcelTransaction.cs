using Tz.Common.DataModel;
using Tz.Common.Values;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tz.Tz.Parcel.DataModel.ParcelEnitities
{
    public class ParcelTransaction :Base,IAuditable
    {
        [Key]
        public Guid ParcelTransactionId { get; set; }

        public Guid LockerId { get; set; }

        public Guid ParcelId { get; set; }

        public TransactionState TransactionState { get; set; }

        public Guid DropOffAgentId { get; set; }

        public int AgentType { get; set; }

        public DateTime DropoffTime { get; set; }


    }
}