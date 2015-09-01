using CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;

namespace DeviceManagerService
{
    public class ComPortProvider : IComPortProvider
    {
        public string ComPort
        {
            get
            {
                return "COM4";
            }
        }
    }
}
