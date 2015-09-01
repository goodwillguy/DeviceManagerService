namespace CommonInterface
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
