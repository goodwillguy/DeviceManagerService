using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.Values;

namespace Tz.Property.DataModel.Entity
{
    [Table("Organisation")]
    public class Organisation:Base
    {
        [Key]
        public Guid OrganisationId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
