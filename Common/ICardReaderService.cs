﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.LockerBank.Common.Interface
{
    public interface ICardReaderService
    {
        void OnSwipe(SwipeEventArgs args);

        event EventHandler<SwipeEventArgs> Swipe;
    }
}
