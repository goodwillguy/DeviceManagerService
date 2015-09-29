using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.LockerBank.Common.Interface
{
    public interface ICardReaderConversionService
    {
        /// <summary>
        /// Used in application, 
        /// </summary>
        /// <param name="cardInput"></param>
        /// <returns></returns>
        string DecodeCardNumber(string cardInput);

        string FormatCardNumer(long rawNumber);
        string FormatFacilityCode(long rawNumber);
    }
}
