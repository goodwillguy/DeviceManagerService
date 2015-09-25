﻿using System;

namespace Tz.LockerBank.Common.Interface
{

    [Flags]
    public enum DeviceStatus
    {
        Unknown = 0,
        Locked = 1,
        Unlocked = 2
    }
}
