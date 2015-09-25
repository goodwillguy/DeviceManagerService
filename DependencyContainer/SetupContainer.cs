using Agent.ApplicationServices;
using Agent.Common.Interface;
using Agent.DataModel.Repository;
using Common.Modules.DataModel;
using Common.Modules.DataModel.Interface;
using Locker.ApplicationService;
using Locker.Common.Interface;
using Locker.DataModel.Repository;
using Parcel.ApplicationService;
using Parcel.Common.Interface;
using Resident.ApplicationServices;
using Resident.Common.Interface;
using Resident.DataModel.Respository;
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
