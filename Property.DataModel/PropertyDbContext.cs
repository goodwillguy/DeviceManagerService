using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.DataModel;
using Tz.Property.DataModel.Entity;
using Tz.Property.DataModel.Migrations;

namespace Tz.Property.DataModel
{
    public class PropertyDbContext : CustomDbContext
    {
        public PropertyDbContext():base("name=Default")
        {
        }

        public PropertyDbContext(string connectionString) : base(connectionString)
        {
          
        }

        public virtual DbSet<Entity.BuildingProperty> BuildingProperties { get; set; }

        public virtual DbSet<Entity.Organisation> Organisations { get; set; }

        public virtual DbSet<Entity.OrganisationToProperty> OrganisationToProperty { get; set; }

        public virtual DbSet<MailRoom> MailRooms { get; set; }

    }
}
