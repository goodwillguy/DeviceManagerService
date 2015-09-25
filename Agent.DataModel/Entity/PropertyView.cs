using Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Agent.DataModel
{
    [ReadonlyTable]
    public class PropertyView 
    {
        [Key]
        public Guid PropertyId { get; set; }

        public string Code { get; set; }

    }
}
