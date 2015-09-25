using Common.DataModel;
using Resident.DataModel.Entitty;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resident.DataModel
{
    [ReadonlyTable]
    public class PropertyView
    {
        [Key]
        public Guid PropertyId { get; set; }

        public string Code { get; set; }

    }
}
