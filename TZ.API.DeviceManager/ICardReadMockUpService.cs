using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TZ.API.DeviceManagement
{
    [ServiceContract]
    public interface ICardReadMockUpService
    {
        [OperationContract]
        string[] GetReaders();

        [OperationContract]
        void Swipe(string rfid, string reader);
    }
}
