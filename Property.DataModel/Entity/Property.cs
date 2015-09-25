using Tz.Common.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Property.DataModel.Entity
{
    public class Property:Base
    {
        [Key]
        public Guid PropertyId { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }

    }
}
