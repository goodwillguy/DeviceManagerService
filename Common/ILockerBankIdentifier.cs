using System.ServiceModel;
using System.ServiceModel.Web;

namespace Tz.LockerBank.Common.Interface
{
    [ServiceContract]
    public interface ILockerBankIdentifier
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        //[WebInvoke(UriTemplate = "GetLockerBankCode",Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string GetLockerBankCode();
    }
}