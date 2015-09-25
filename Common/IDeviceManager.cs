using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LockerBank.Common.Interface
{
    [ServiceContract]
    public interface IDeviceManager
    {
        [OperationContract]
        Device[] GetAllDevices();

        [OperationContract]
        Device GetDevice(string serialNumber);


        [OperationContract]
        bool Open(string serialNumber);

        [OperationContract(Name = "OpenDevicesCollection")]
        void Open(string[] serialNumbers);

        [OperationContract]
        string GetFirmwareVersion();

        [OperationContract]
        bool IsReady();

        event EventHandler<DeviceChangedEventArg> DeviceChanged;
        event EventHandler DeviceInitialized;
    }

}
