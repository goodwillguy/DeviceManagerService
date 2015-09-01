using DeviceManagerService.App_Start;
using SimpleInjector.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using CommonInterface;
namespace DeviceManagerService
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var cont = Bootstrapper.Container;

            //a.CreateServiceHost(string.Empty,)


            //  var deviceMgr = Bootstrapper.Container.GetInstance<IDeviceManager>();
            using (var host = new SimpleInjectorServiceHost(cont, typeof(DeviceManagerServiceHost)))
            {
                host.Open();
                Console.ReadKey();

            }

            //using (var host = new SimpleInjectorServiceHost(Bootstrapper.Container, typeof(DeviceManager)))
            //{
            //    host.Open();
            //    Console.ReadKey();

            //}

            var a = new WcfServiceFactory();
            a.CreateServiceHost(string.Empty, null);

        }
    }
}
