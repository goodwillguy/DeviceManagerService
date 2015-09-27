using Tz.Common.Values.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.ApplicationServices.Common.Interface
{
    public interface IDropOffEvent
    {
        void DoDropOff(string lockerBankCode, Guid residentId, Size parcelSize, string consignmentNumber, Guid operatorId, Guid agentDropOffId);
    }
}
