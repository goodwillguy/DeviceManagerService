using Tz.LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tz.DeviceManagerService
{
    public class CardReaderService : ICardReaderEventsSubscribe,IWebCardReaderEventsSubscribe,IDisposable
    {
        private readonly ICardReaderService _cardReader;

        Dictionary<string, ICardReaderEventsCallBack> _cardReaderSubscription = new Dictionary<string, ICardReaderEventsCallBack>();

        Dictionary<string, IWebCardReaderEventsCallBack> _webCardReaderSubscription = new Dictionary<string, IWebCardReaderEventsCallBack>();
        System.Timers.Timer time = new System.Timers.Timer();
        private readonly ICardReaderConversionService _cardNumberConversion;

        public CardReaderService(ICardReaderService cardReader, ICardReaderConversionService cardNumberConversion)
        {
            time.Elapsed += Time_Elapsed;
            _cardReader = cardReader;
            _cardNumberConversion = cardNumberConversion;
            _cardReader.Swipe += _cardReader_Swipe;
            time.Interval = 60 * 1000;
            time.Start();
        }

        private void Time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //_cardReader_Swipe(this, new SwipeEventArgs { RFID = "123456", SerialNumber="123456" });
        }

        private void _cardReader_Swipe(object sender, SwipeEventArgs e)
        {
            var cardNumber = _cardNumberConversion.DecodeCardNumber(e.RFID);

            var list = _cardReaderSubscription.ToArray();

            var webList = _webCardReaderSubscription.ToArray();

            foreach (var key in list)
            {
                try
                {
                    key.Value.SendCardSwipeByName(cardNumber);
                }
                catch (ObjectDisposedException ex)
                {
                    _cardReaderSubscription.Remove(key.Key);
                }
            }


            foreach (var key in webList)
            {
                try
                {
                    key.Value.SendCardSwipe(CreateMessage(cardNumber));
                }
                catch (ObjectDisposedException ex)
                {
                    _webCardReaderSubscription.Remove(key.Key);
                }
            }

        }

        public void SubscribeToCardSwipe(Message message)
        {
            var current = OperationContext.Current.GetCallbackChannel<IWebCardReaderEventsCallBack>();


            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            WebSocketMessageProperty property =
                (WebSocketMessageProperty)message.Properties["WebSocketMessageProperty"];
            WebSocketContext context = property.WebSocketContext;

            var queryParameters = HttpUtility.ParseQueryString(context.RequestUri.Query);
            string content = string.Empty;

            if (!message.IsEmpty)
            {
                byte[] body = message.GetBody<byte[]>();
                content = Encoding.UTF8.GetString(body);
            }



            // Do something with the content/queryParams
            // ...

            string str = null;
            if (string.IsNullOrEmpty(content)) // Connection open message
            {
                str = "Opening connection from host " + queryParameters["Name"].ToString();
            }
            else // Message received from client
            {
                str = "Received message: " + content;
            }

            var hostName = queryParameters["Name"].ToString();

            if (!_webCardReaderSubscription.ContainsKey(hostName))
            {
                _webCardReaderSubscription.Add(hostName, current);
            }
            else
            {
                _webCardReaderSubscription[hostName] = current;
            }



          // current.SendCardSwipe(CreateMessage(str));
        }

        private Message CreateMessage(string content)
        {
            Message message = ByteStreamMessage.CreateMessage(
                new ArraySegment<byte>(
                    Encoding.UTF8.GetBytes(content)));
            message.Properties["WebSocketMessageProperty"] =
                new WebSocketMessageProperty
                { MessageType = WebSocketMessageType.Text };

            return message;
        }

        public void SubscribeToCardSwipeByhost(string hostName)
        {
            var current = OperationContext.Current.GetCallbackChannel<ICardReaderEventsCallBack>();


            if (_cardReaderSubscription.ContainsKey(hostName))
            {
                _cardReaderSubscription.Add(hostName, current);
            }
            else
            {
                _cardReaderSubscription[hostName] = current;
            }



            current.SendCardSwipeByName("Received Subscription");
        }

        public void Dispose()
        {
            _cardReader.Swipe -= _cardReader_Swipe;
        }
    }
}
