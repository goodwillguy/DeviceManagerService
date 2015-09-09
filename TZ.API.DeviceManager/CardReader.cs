using CommonInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.API.DeviceManagement
{
    public class CardReaderListner : ICardReaderService
    {
        public void OnSwipe(SwipeEventArgs args)
        {
            if(Swipe!=null)
            {
                Swipe(this, args);
            }
        }

        public event EventHandler<SwipeEventArgs> Swipe;
    }
}
