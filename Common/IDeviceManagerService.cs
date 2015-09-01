using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterface
{
    [ServiceContract]
    public interface IDeviceManagerService
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
    }
}
