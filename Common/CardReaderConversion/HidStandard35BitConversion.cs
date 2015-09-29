using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.LockerBank.Common.Interface.CardReaderConversion
{
    public class HidStandard35BitConversion : BitHexConversion
    {
        public HidStandard35BitConversion() : base()
        {
        }

        protected override int BinaryFacilityCodeLength
        {
            get { return 12; }
        }

        protected override int BinaryCardNumberLength
        {
            get { return 20; }
        }

        protected override int TotalLength
        {
            get { return 33; }
        }

        protected override int DecodedFacilityCodeLength
        {
            get { return 4; }
        }

        protected override int DecodedCardNumberLength
        {
            get { return 7; }
        }
    }
}
