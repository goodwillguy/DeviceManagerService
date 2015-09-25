using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Tz.LockerBank.Common.Interface
{
    public class LockerBankChannelFactory : ILockerBankChannelFactory
    {
        private Uri GetUriFromConfig(Type channelType)
        {
            Dictionary<string, Uri> addresses = new Dictionary<string, Uri>();

            ClientSection clientSection = (ClientSection)ConfigurationManager.GetSection("system.serviceModel/client");

            foreach (ChannelEndpointElement endpoint in clientSection.Endpoints)
            {

                return endpoint.Address;
            }
            return null;
        }
        private string GetEndpointAddress<T>(string ipAddress)
        {
            Uri templateUri = GetUriFromConfig(typeof(T));

            UriBuilder builder = new UriBuilder(templateUri.Scheme, ipAddress, templateUri.Port, templateUri.PathAndQuery);

            return builder.Uri.ToString();
        }


        public T CreateChannel<T>(string ipAddress)
        {
            string url = this.GetEndpointAddress<T>(ipAddress);
            EndpointAddress addr = new EndpointAddress(url);
            ChannelFactory factory = new ChannelFactory<T>("*", addr);

            Task<T> task = Task.Factory.StartNew<T>(() =>
            {
                T rs = ((ChannelFactory<T>)factory).CreateChannel(addr);
                return rs;
            });
            task.Wait();
            return task.Result;
        }
    }
}
