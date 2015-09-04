using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterface
{
    [ServiceContract]
    public interface ICardReaderEventsCallBack
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SendCardSwipe(Message message);
    }

    [ServiceContract(CallbackContract =typeof(ICardReaderEventsCallBack))]
    public interface ICardReaderEventsSubscribe
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubscribeToCardSwipe(Message message);
    }
}
