using CommonInterface;

namespace TZ.API.DeviceManagement
{
    public interface IDeviceManagerFactory
    {
        IDeviceManager CreateManager();
    }
}
