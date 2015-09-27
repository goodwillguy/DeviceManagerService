using Tz.Common.DataModel;
using Tz.Resident.DataModel.Entitty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tz.Resident.DataModel
{
    [ReadonlyTable]
    [Table("BuildingProperty")]
    public class BuildingPropertyView
    {
        [Key]
        public Guid BuildingPropertyId { get; set; }

        public string Code { get; set; }

    }
}
