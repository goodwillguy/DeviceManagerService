using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.DataModel.Interface;
using Tz.Resident.DataModel.Migrations;

namespace Tz.Resident.DataModel.Respository
{
    public class InitialiseDataModel : IInitialiseDb
    {
        public void InitialiseDb()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}
