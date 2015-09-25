using Common.Values;
using Common.Values.Enums;
using System;
using System.Collections.Generic;

namespace Parcel.Common.Dto
{
    public class ParcelDto: Base
    {
        public Guid ParcelId { get; set; }

        public Guid OrganizationId { get; set; }

        public string ConsignmentNumber { get; set; }

        public Guid? SenderId { get; set; }

        public Guid RecipientId { get; set; }

        public Size Size { get; set; }

        public bool IsExpired { get; set; }

        public DateTime ExpiryTime { get; set; }

        public Guid LockerBankId { get; set; }

        public Guid? LockerId { get; set; }

        public List<ParcelTransactionDto> ParcelTransactions { get; set; }
    }
}