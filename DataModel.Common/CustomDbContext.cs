using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataModel
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(string connectionString) : base(connectionString)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
