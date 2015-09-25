using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockerBank.Common.Interface
{
    public class SwipeEventArgs : EventArgs
    {
        public string SerialNumber { get; set; }

        public string RFID { get; set; }
    }
}
