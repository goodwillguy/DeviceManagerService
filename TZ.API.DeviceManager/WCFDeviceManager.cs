using CommonInterface;
using System.ServiceModel;
using System.Threading;
using TZ.Common;
using TZ.ServiceModel;

namespace TZ.API.DeviceManagement
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class WCFDeviceManager : DeviceManager
    {
        public WCFDeviceManager(ILogger logger, IComPortProvider comPortProvider) :base(logger,comPortProvider)
        {
        }
        private ServiceHost _host;


        public override void InitializeService()
        {
            _host = new ServiceHost(this);
            ThreadPool.QueueUserWorkItem(o => {
                
                _host.Open();
            });

            base.InitializeService();
        }

        public override void UninitializeService()
        {
            this._host.Close();
            base.UninitializeService();
        }
    }
}
