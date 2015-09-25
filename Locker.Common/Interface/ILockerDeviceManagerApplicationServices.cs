using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Locker.Common.Interface
{
    public interface ILockerDeviceManagerApplicationServices
    {
        void OpenLocker(Guid lockerBankId, Guid lockerId);
    }
}
