using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TZ.API.DeviceManagement
{
    public class SwipeEventArgs : EventArgs
    {
        public string SerialNumber { get; set; }

        public string RFID { get; set; }
    }
}
