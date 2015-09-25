using Tz.LockerBank.Common.Interface;

namespace TZ.API.DeviceManagement
{
    public interface IDeviceManagerFactory
    {
        IDeviceManager CreateManager();
    }
}
