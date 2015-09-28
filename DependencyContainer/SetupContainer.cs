using Tz.Agent.ApplicationServices;
using Tz.Agent.Common.Interface;
using Tz.Agent.DataModel.Repository;
using Common.Modules.DataModel;
using Common.Modules.DataModel.Interface;
using Tz.Locker.ApplicationService;
using Tz.Locker.Common.Interface;
using Tz.Locker.DataModel.Repository;
using Tz.Parcel.ApplicationService;
using Tz.Parcel.Common.Interface;
using Tz.Resident.ApplicationServices;
using Tz.Resident.Common.Interface;
using Tz.Resident.DataModel.Respository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Parcel.DataModel.Repository;
using System.Reflection;
using Tz.Common.DataModel;
using Tz.Property.Common.Interface;
using Tz.Property.DataModel.Repository;
using Tz.Property.DataModel;
using Tz.Resident.DataModel;
using Tz.Property.DataModel.Migrations;
using Tz.ApplicationServices.Common.Interface;
using Tz.LockerBank.Common.Interface;
using Tz.Common.DataModel.Interface;
using Tz.DropOff.ApplicationService;
using Tz.Resident.ApplicationService;
using Tz.AgentValidation;

namespace DependencyContainer
{
    public class SetupContainer
    {
        static Container _container = null;
        public static void SetupDependency(Container container)
        {
            if (container == null)
            {
                container = new Container();
            }
            _container = container;
            container.Register<IConnectionStringFactory, ConnectionStringFactory>(Lifestyle.Singleton);


            ParcelModuleRegister(container);
            LockerModuleRegister(container);

            ResidentModuleRegister(container);

            AgentModuleRegister(container);

            PropertyModuleRegister(container);

            ApplicationServiceRegister(container);

            LockerBankChannel(container);

            //container.Verify();
            SetupDb();
        }

        private static void LockerBankChannel(Container container)
        {
            container.Register<ILockerBankChannelFactory, LockerBankChannelFactory>();
        }

        private static void ApplicationServiceRegister(Container container)
        {
            container.Register<IDropOffEvent, DropOffHandler>();

            container.Register<IResidentService, ResidentWorkService>();

            container.Register<IValidateAgent, AgentWorkFlowServices>();
        }

        private static void PropertyModuleRegister(Container container)
        {
            container.Register<IPropertyRepository, PropertyRepository>();
        }

        private static void SetupDb()
        {
            var connectionString = _container.GetInstance<IConnectionStringFactory>();

            //  //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PropertyDbContext, Tz.Property.DataModel.Migrations.Configuration>());

            ///*  foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(ass => ass.Name.StartsWith("Tz")))
            //  {
            //      Assembly assembly = Assembly.Load(assemblyName);
            //      foreach (var type in assembly.GetTypes())
            //      {
            //          if (typeof(CustomDbContext).IsAssignableFrom(type) && typeof(CustomDbContext) != type)
            //          {
            //              if (type == typeof(PropertyDbContext))
            //              {
            //                  Database.SetInitializer(new MigrateDatabaseToLatestVersion<PropertyDbContext, Configuration>());
            //                  var migrator = new DbMigrator(new Configuration());
            //                  migrator.Update();
            //              }
            //              //var context = Activator.CreateInstance(type, connectionString.GetConnectionString()) as CustomDbContext;

            //              ////context.InitializeDb();
            //              //context.Database.Initialize(true);

            //             // context.Dispose();
            //          }
            //      }
            //  }*/

            //  //using (var con = new PropertyDbContext(connectionString.GetConnectionString()))
            //  //{
            //  //    con.Properties.ToList();
            //  //}


            List<IInitialiseDb> intialiseDbOrder = new List<IInitialiseDb>();

            intialiseDbOrder.Add(new Tz.Property.DataModel.Repository.InitialiseDataModel());
            intialiseDbOrder.Add(new Tz.Locker.DataModel.Repository.InitialiseDataModel());
            intialiseDbOrder.Add(new Tz.Agent.DataModel.Repository.InitialiseDataModel());
            intialiseDbOrder.Add(new Tz.Resident.DataModel.Respository.InitialiseDataModel());
            intialiseDbOrder.Add(new Tz.Parcel.DataModel.Repository.InitialiseDataModel());



            foreach(var dbinitilise in intialiseDbOrder)
            {
                dbinitilise.InitialiseDb();
            }


        }

        private static void AgentModuleRegister(Container container)
        {
            container.Register<IAgentRepository, AgentRepository>();
            container.Register<IAgentApplicationServices, AgentApplicationService>();
        }

        private static void ResidentModuleRegister(Container container)
        {
            container.Register<IResidentRepository, ResidentRespository>();
            container.Register<IResidentApplicationService, ResidentApplicationServices>();

        }

        static void ParcelModuleRegister(Container container)
        {
            container.Register<IParcelRepository, ParcelRepository>();
            container.Register<IDropOffParcel, ParcelApplicationService>();

        }

        static void LockerModuleRegister(Container container)
        {
            container.Register<ILockerRepository, LockerRepository>();

            container.Register<ILockerApplicationService, LockerApplicationService>();

            container.Register<ILockerDeviceManagerApplicationServices, LockerDeviceManagerApplicationService>();
        }
    }
}
