using System;

namespace CommonInterface
{

    [Flags]
    public enum DeviceStatus
    {
        Unknown = 0,
        Locked = 1,
        Unlocked = 2
    }
}
