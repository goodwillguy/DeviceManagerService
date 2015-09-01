using CommonInterface;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using TZ.ServiceModel;

namespace DeviceManagerService.App_Start
{
    public static class Bootstrapper
    {
        public static readonly Container Container;

        static Bootstrapper()
        {
            var con = new Container();
            con.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

            // register all your components with the container here:
            // container.Register<IService1, Service1>()
            // container.Register<IDataContext, DataContext>(Lifestyle.Scoped);

            Register(con);

           // container.Verify();

            Container = con;

            SimpleInjectorServiceHostFactory.SetContainer(Container);
        }

        static void Register(Container container)
        {
            container.Register<ILogger, LogService>(Lifestyle.Singleton);

            container.Register<IComPortProvider, ComPortProvider>(Lifestyle.Singleton);

            container.Register<IDeviceManager, DeviceManager>(Lifestyle.Singleton);

            container.Register<IDeviceManagerService, DeviceManagerServiceHost>(Lifestyle.Singleton);

            container.RegisterWcfServices(Assembly.GetExecutingAssembly());

        }
    }
}
