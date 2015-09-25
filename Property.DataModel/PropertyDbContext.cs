using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.DataModel;

namespace Tz.Property.DataModel
{
    public class PropertyDbContext : CustomDbContext
    {
        public PropertyDbContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Entity.Property> Properties { get; set; }


    }
}
