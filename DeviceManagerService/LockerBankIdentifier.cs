using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Tz.DeviceManagerService.Properties;
using Tz.LockerBank.Common.Interface;

namespace Tz.DeviceManagerService
{
    public class LockerBankIdentifier : ILockerBankIdentifier
    {
        public LockerBankIdentifier()
        {

        }
        public string GetLockerBankCode()
        {
            return Settings.Default.Identification;
        }
    }
}
