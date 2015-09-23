using Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker.DataModel
{
    public class PropertyView:IReadonlyEntity
    {
        [Key]
        public Guid PropertyId { get; set; }

        public string Code { get; set; }

    }
}
