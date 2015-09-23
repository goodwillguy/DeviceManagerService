using Autofac;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<EchoService>();

            using (IContainer container = builder.Build())
            {
                Uri address = new Uri("http://localhost:8080/EchoService");
                ServiceHost host = new ServiceHost(typeof(EchoService), address);

                var basicHttpBinding = new BasicHttpBinding();
                host.AddServiceEndpoint(typeof(IEchoService), basicHttpBinding, string.Empty);
                host.AddServiceEndpoint(typeof(IEchoService2), basicHttpBinding, string.Empty);

                host.AddDependencyInjectionBehavior<EchoService>(container);

                host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true, HttpGetUrl = address });
                host.Open();

                Console.WriteLine("The host has been opened.");
                Console.ReadLine();

                host.Close();
                Environment.Exit(0);
            }
        }
    }


    [ServiceContract]
    public interface IEchoService
    {
        [OperationContract]
        string Test();
    }

    [ServiceContract]
    public interface IEchoService2
    {
        [OperationContract]
        string Test2();
    }

    public interface ILogger
    {
    }

    public class EchoService : IEchoService, IEchoService2
    {
        private readonly ILogger logger;

        //just to see that Autofac inject the dependicies
        public EchoService(ILogger logger)
        {
            this.logger = logger;
        }

        public string Test()
        {
            return "TEst1";
        }

        public string Test2()
        {
            return "TEst1";
        }
    }

    public class Logger : ILogger
    {

    }
}
