using Common.DataModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tz.Parcel.DataModel.ParcelEnitities
{
    public class ParcelTransaction :Base,IAuditable
    {
        [Key]
        public Guid ParcelTransactionId { get; set; }

        public Guid LockerId { get; set; }

        public Guid ParcelId { get; set; }

        public int TransactionState { get; set; }

        public Guid DropOffAgentId { get; set; }

        public int AgentType { get; set; }

        public DateTime DropoffTime { get; set; }


    }
}