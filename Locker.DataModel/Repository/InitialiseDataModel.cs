﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.DataModel.Interface;
using Tz.Locker.DataModel.Migrations;

namespace Tz.Locker.DataModel.Repository
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
