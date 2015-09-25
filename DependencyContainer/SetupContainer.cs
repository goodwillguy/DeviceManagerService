using Common.Modules.DataModel;
using Common.Modules.DataModel.Interface;
using Locker.ApplicationService;
using Locker.Common.Interface;
using Locker.DataModel.Repository;
using Parcel.ApplicationService;
using Parcel.Common.Interface;
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

            container.Register<IParcelRepository, ParcelRepository>();

            container.Register<ILockerRepository, LockerRepository>();

            container.Register<ILockerApplicationService, LockerApplicationService>();

            container.Register<IDropOffParcel, ParcelApplicationService>();
        }
    }
}
