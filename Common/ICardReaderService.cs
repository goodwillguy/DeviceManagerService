using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterface
{
    public interface ICardReaderService
    {
        event EventHandler<SwipeEventArgs> Swipe;
    }
}
