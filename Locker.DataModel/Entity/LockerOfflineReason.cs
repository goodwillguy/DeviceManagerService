﻿using Common.DataModel;
using Common.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker.DataModel
{
    public class LockerOfflineReason :Base
    {

        public Guid LockerOfflineReasonId { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }
    }
}