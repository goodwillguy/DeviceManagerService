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
    [Table("OrganisationToProperty")]
    public class OrganisationToProperty:Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrganisationToPropertyId { get; set; }

        public Guid OrganisationId { get; set; }

       
        public Guid BuildingPropertyId { get; set; }

        [ForeignKey("OrganisationId")]

        public virtual Organisation OrganisationData { get; set; }

        [ForeignKey("BuildingPropertyId")]
        public virtual BuildingProperty Property { get; set; }
    }
}
