using Tz.LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using System.ServiceModel.Channels;
using System.Net.WebSockets;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var fact = new ChannelFactory<IDeviceManagerService>("deviceEndpoint");

            InstanceContext callback = new InstanceContext(new ServiceCallback());

            var dup = new DuplexChannelFactory<ICardReaderEventsSubscribe>(callback, "dupSocket");


            var cardReaderSub = dup.CreateChannel();


            var cha = fact.CreateChannel();

            using (fact)
            {
                var devices = cha.GetAllDevices();
                //cha.Open(new  devices[0].FullSerialNumber );


            }
            Console.WriteLine("try a new");
            Console.ReadKey();

            Console.WriteLine("REading duplex");

            cardReaderSub.SubscribeToCardSwipeByhost("Local");

            Console.ReadKey();

            var fact1 = new ChannelFactory<IDeviceManagerService>("deviceEndpoint");
            var cha1 = fact1.CreateChannel();

            using (fact1)
            {
                var devices = cha1.GetAllDevices();
            }
        }

        private static Message CreateMessage(string content)
        {
            Message message = ByteStreamMessage.CreateMessage(
                new ArraySegment<byte>(
                    Encoding.UTF8.GetBytes(content)));
            message.Properties["WebSocketMessageProperty"] =
                new WebSocketMessageProperty
                { MessageType = WebSocketMessageType.Text };

            return message;
        }
    }


    public class ServiceCallback : ICardReaderEventsCallBack
    {
        public void SendCardSwipe(Message message)
        {
            Console.WriteLine("received message");
        }

        public void SendCardSwipeByName(string message)
        {
            Console.WriteLine(string.Format("received message : {0}",message));
        }
    }


}
