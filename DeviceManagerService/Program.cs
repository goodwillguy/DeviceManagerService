using Tz.DeviceManagerService.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using Tz.LockerBank.Common.Interface;
using Autofac.Integration.Wcf;
using Autofac;
using System.ServiceModel.Description;

namespace Tz.DeviceManagerService
{
    class Program
    {
        static void Main(string[] args)
        {
            var cont = Bootstrapper.Container;

            ServiceHost host = new ServiceHost(typeof(DeviceManagerServiceHost));

            host.AddDependencyInjectionBehavior<IDeviceManagerService>(Bootstrapper.Container);

            host.Open();


            ServiceHost host1 = new ServiceHost(typeof(CardReaderService));

            host1.AddDependencyInjectionBehavior<IWebCardReaderEventsSubscribe>(Bootstrapper.Container);

            host1.Open();

            Console.ReadKey();
        }
    }
}
