using CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var fact = new ChannelFactory<IDeviceManagerService>("deviceEndpoint");
            var cha = fact.CreateChannel();

            using (fact)
            {
                var devices = cha.GetAllDevices();
            }
            Console.WriteLine("try a new");
            Console.ReadKey();



            var fact1 = new ChannelFactory<IDeviceManagerService>("deviceEndpoint");
            var cha1 = fact1.CreateChannel();

            using (fact1)
            {
                var devices = cha1.GetAllDevices();
            }
        }
    }
}
