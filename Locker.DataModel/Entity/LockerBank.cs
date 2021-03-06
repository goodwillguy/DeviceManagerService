﻿using Tz.Common.DataModel;
using Tz.Common.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tz.Locker.DataModel
{
    [Table("LockerBank")]
    public class LockerBank:Base,IAuditable
    {
        [Key]
        public Guid LockerBankId { get; set; }

        [Required]
        public string LockerBankCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IpAddress { get; set; }

        public bool IsEnabled { get; set; }

        [Required]
        public Guid BuildingPropertyId { get; set; }

        [ForeignKey("BuildingPropertyId")]
        public virtual BuildingPropertyView BuildingProperty { get; set; }
        
    }
}
