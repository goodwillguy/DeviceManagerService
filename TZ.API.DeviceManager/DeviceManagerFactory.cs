using LockerBank.Common.Interface;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using TZ.ServiceModel;

namespace TZ.API.DeviceManagement
{
    public class DeviceManagerFactory : ServiceBase, IDeviceManagerFactory
    {

        ChannelFactory<IDeviceManager> _factory;

        public override void InitializeService()
        {
            _factory = new ChannelFactory<IDeviceManager>("DeviceManager");
            base.InitializeService();
        }

        #region IDeviceManagerFactory Members

        public IDeviceManager CreateManager()
        {
            return _factory.CreateChannel();
        }

        #endregion

        private EndpointAddress address = null;

        private EndpointAddress GetAddress()
        {
            Type t = typeof(IDeviceManager);
            EndpointAddress rs = null;

            if (rs == null)
            {
                ClientSection cs = (ClientSection)System.Configuration.ConfigurationManager.GetSection("system.serviceModel/client");
                var q1 = from e in cs.Endpoints.Cast<ChannelEndpointElement>() where e.Contract == t.FullName select e.Address;

                Uri uri = q1.Single();
                rs = new EndpointAddress(uri);
            }

            return rs;
        }
    }
}
