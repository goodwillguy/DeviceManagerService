using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modules.DataModel.Interface
{
    public interface IConnectionStringFactory
    {
        string GetConnectionString(string regionDiffrentiator="");
    }
}
