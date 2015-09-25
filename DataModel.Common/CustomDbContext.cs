using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Common.DataModel
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext()
        {

        }
        public CustomDbContext(string connectionString) : base(connectionString)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string annotationValue = typeof(ReadonlyTableAttribute).ToString();
            modelBuilder.Conventions.Add(new AttributeToTableAnnotationConvention<ReadonlyTableAttribute, string>("MyAnnotation", (entityType, attributes) => annotationValue));
            base.OnModelCreating(modelBuilder);
        }
    }
}
