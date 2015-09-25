using Tz.Common.DataModel;
using Tz.Common.Values;
using Tz.Common.Values.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Locker.DataModel
{
    public class Device:Base,IAuditable
    {
        public Guid DeviceId { get; set; }
        public Guid LockerBankId { get; set; }

        public string SerialNumber { get; set; }
        public bool IsEnabled { get; set; }

        public DeviceType DeviceType { get; set; }

    }
}
