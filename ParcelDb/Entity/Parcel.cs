﻿using Tz.Common.DataModel;
using Tz.Common.Values;
using Tz.Common.Values.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tz.Parcel.DataModel.ParcelEnitities
{
    [Table("Parcel")]
    public class Parcel : Base, IAuditable
    {
        [Key]
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

        public Guid? MailRoomId { get; set; }

        public virtual List<ParcelTransaction> ParcelTransactions { get; set; }

        [ForeignKey("LockerId")]
        public virtual LockerView Locker { get; set; }


    }
}
