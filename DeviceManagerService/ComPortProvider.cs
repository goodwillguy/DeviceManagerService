using Tz.LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using System.Configuration;
using Tz.DeviceManagerService.Properties;

namespace Tz.DeviceManagerService
{
    public class ComPortProvider : IComPortProvider
    {
        
        public string ComPort
        {
            get
            {
                return Settings.Default.ComPort;
            }
        }
    }
}
