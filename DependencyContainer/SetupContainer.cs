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

namespace DependencyContainer
{
    public class SetupContainer
    {
        public static void SetupDependency(Container container)
        {
            if (container == null)
            {
                container = new Container();
            }

            container.Register<IConnectionStringFactory, ConnectionStringFactory>(Lifestyle.Singleton);


            ParcelModuleRegister(container);
            LockerModuleRegister(container);

            ResidentModuleRegister(container);

            AgentModuleRegister(container);

            
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
        }
    }
}
