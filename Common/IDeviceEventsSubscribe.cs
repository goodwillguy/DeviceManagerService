using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace LockerBank.Common.Interface
{
    [ServiceContract]
    public interface ICardReaderEventsCallBack
    {
        //[OperationContract(IsOneWay = true, Action = "*")]
        //void SendCardSwipe(Message message);

        [OperationContract(IsOneWay = true, Action = "*")]
        void SendCardSwipeByName(string message);
    }

    [ServiceContract(CallbackContract =typeof(ICardReaderEventsCallBack))]
    public interface ICardReaderEventsSubscribe
    {
        //[OperationContract(IsOneWay = true, Action = "*")]
        //void SubscribeToCardSwipe(Message message);

        [OperationContract(IsOneWay = true, Action = "*")]
        void SubscribeToCardSwipeByhost(string hostName);
    }


    [ServiceContract]
    public interface IWebCardReaderEventsCallBack
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SendCardSwipe(Message message);
    }

    [ServiceContract(CallbackContract = typeof(IWebCardReaderEventsCallBack))]
    public interface IWebCardReaderEventsSubscribe
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubscribeToCardSwipe(Message message);

    }


}
