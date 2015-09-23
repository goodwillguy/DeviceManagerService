using Common.DataModel;
using Common.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker.DataModel
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
