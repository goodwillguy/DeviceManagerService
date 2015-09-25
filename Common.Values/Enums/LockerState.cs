using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Values.Enums
{
    public enum LockerState
    {

        Available = 0,


        Flagged = 1,


        Deleted = 2,

        Occupied = 3
    }


    public enum Size
    {
        Undefined = 0,

        Small = 1,

        Medium = 2,

        Large = 3,
    }

    public enum DeviceType
    {
        Radials,
        CardReader
    }
}
