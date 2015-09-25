namespace LockerBank.Common.Interface
{
    public class DeviceChangedEventArg
    {
        public DeviceChangedEventArg(Device device)
        {
            this.Device = device;
        }

        public Device Device { get; set; }
    }
}
