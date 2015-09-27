using Tz.Common.DataModel;
using Tz.Common.Values;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tz.Parcel.DataModel.Entity;

namespace Tz.Parcel.DataModel.ParcelEnitities
{
    [Table("ParcelTransaction")]
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

        [ForeignKey("ParcelId")]
        public virtual Parcel Parcel { get; set; }
        [ForeignKey("DropOffAgentId")]
        public virtual AgentView DropOffAgent { get; set; }
    }
}