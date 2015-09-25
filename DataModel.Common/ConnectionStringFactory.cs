using Common.Modules.DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modules.DataModel
{
    public class ConnectionStringFactory : IConnectionStringFactory
    {
        const string DefaultConnectionString = "Default";
        public string GetConnectionString(string regionDiffrentiator="")
        {
            return ConfigurationManager.ConnectionStrings[DefaultConnectionString].ConnectionString;
        }
    }
}
