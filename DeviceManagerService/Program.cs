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
            var deviceManagerHost = new SimpleInjectorServiceHost(cont, typeof(DeviceManagerServiceHost));

            deviceManagerHost.Open();

            var cardReader = new SimpleInjectorServiceHost(cont, typeof(CardReaderService));

            cardReader.Open();

            Console.ReadKey();


            deviceManagerHost.Close();
            cardReader.Close();

        }

        //using (var host = new SimpleInjectorServiceHost(Bootstrapper.Container, typeof(DeviceManager)))
        //{
        //    host.Open();
        //    Console.ReadKey();

        //}

    }
}
