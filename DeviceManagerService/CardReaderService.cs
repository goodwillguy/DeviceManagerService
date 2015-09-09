﻿using CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DeviceManagerService
{
    public class CardReaderService : ICardReaderEventsSubscribe
    {
        private readonly ICardReaderService _cardReader;

        Dictionary<string, ICardReaderEventsCallBack> _cardReaderSubscription = new Dictionary<string, ICardReaderEventsCallBack>();

        public CardReaderService(ICardReaderService cardReader)
        {
            _cardReader = cardReader;
            _cardReader.Swipe += _cardReader_Swipe;
        }

        private void _cardReader_Swipe(object sender, SwipeEventArgs e)
        {
            var list = _cardReaderSubscription.ToArray();
            foreach (var key in list)
            {
                try
                {
                    key.Value.SendCardSwipe(CreateMessage(e.RFID));
                }
                catch (ObjectDisposedException ex)
                {
                    _cardReaderSubscription.Remove(key.Key);
                }
            }

        }

        public void SubscribeToCardSwipe(Message message)
        {
            var current = OperationContext.Current.GetCallbackChannel<ICardReaderEventsCallBack>();


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

            if (_cardReaderSubscription.ContainsKey(hostName))
            {
                _cardReaderSubscription.Add(hostName, current);
            }
            else
            {
                _cardReaderSubscription[hostName] = current;
            }



            current.SendCardSwipe(CreateMessage(str));
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
    }
}