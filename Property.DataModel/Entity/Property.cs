﻿using Tz.Common.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tz.Property.DataModel.Entity
{
    [Table("BuildingProperty")]
    public class BuildingProperty:Base
    {
        [Key]
        public Guid BuildingPropertyId { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }

    }
}
