using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.DataModel.Interface;

namespace Tz.Common.DataModel
{
    public abstract class CustomDbContext : DbContext
    {
        public CustomDbContext()
        {

        }
        public CustomDbContext(string connectionString) : base(connectionString)
        {
           // Database.SetInitializer<CustomDbContext>(null);
            //Type MyType = this.GetType();

            //var typeOfContext = typeof(Database);

            //var method = typeOfContext.GetMethod("SetInitializer");

            //var genericMethod = method.MakeGenericMethod(MyType);

            //method.Invoke(genericMethod, null);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static void  InitialiseDb()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string annotationValue = typeof(ReadonlyTableAttribute).ToString();
            modelBuilder.Conventions.Add(new AttributeToTableAnnotationConvention<ReadonlyTableAttribute, string>("MyAnnotation", (entityType, attributes) => annotationValue));
            base.OnModelCreating(modelBuilder);
        }
    }
}
