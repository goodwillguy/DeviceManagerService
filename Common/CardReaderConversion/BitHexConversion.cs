using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.LockerBank.Common.Interface.CardReaderConversion
{
    public class Constants
    {
        public const int Decimal = 10;
        public const int Hex = 16;
        public const int Binary = 2;
    }
    public abstract class BitHexConversion : ICardReaderConversionService
    {
        protected abstract int BinaryFacilityCodeLength { get; }
        protected abstract int BinaryCardNumberLength { get; }
        protected int TotalValidLength;
        protected abstract int TotalLength { get; }
        protected abstract int DecodedFacilityCodeLength { get; }
        protected abstract int DecodedCardNumberLength { get; }

        public BitHexConversion()
        {
            TotalValidLength = BinaryFacilityCodeLength + BinaryCardNumberLength;
        }

        /// <summary>
        /// DecodeCardNumber 
        /// Before using this method, set the  TZCardParserGlobalSettings.Default.FacilityCodeLength = 2
        /// and TZCardParserGlobalSettings.Default.CardNumberLength = 5
        /// </summary>
        /// <param name="cardInput">Scanned raw input</param>
        /// <param name="facilityCodeFormatlength">Valid Length of facility code, PadLen char = 0</param>
        /// <param name="cardnumberFormatLength">Valid Length of card number, PadLen char = 0</param>
        /// <returns>string(facilitycode_cardnumber)</returns>
        public virtual string DecodeCardNumber(string cardInput)
        {
            //Test cases
            //string cardInput = "0000 0000 00B1AACD";

            var cardInputDec = Convert.ToInt64(cardInput, Constants.Hex);
            var binaryPresentation = Convert.ToString(cardInputDec, Constants.Binary).PadLeft(TotalValidLength, '0');

            var validBinaryData = binaryPresentation.Substring(binaryPresentation.Length - TotalValidLength);

            var binaryFacilityCode = validBinaryData.Substring(0, BinaryFacilityCodeLength);
            var binaryCardNumber = validBinaryData.Substring(validBinaryData.Length - BinaryCardNumberLength);

            var cardNoLong = Convert.ToInt64(binaryCardNumber, Constants.Binary);
            var facilityCodeLong = Convert.ToInt64(binaryFacilityCode, Constants.Binary);

            var cardNumber = this.FormatCardNumer(cardNoLong);
            var siteCode = this.FormatFacilityCode(facilityCodeLong);

            return CreateFullCardNumber(siteCode, cardNumber);
        }

        public virtual string FormatCardNumer(long rawNumber)
        {
            return rawNumber.ToString("D" + DecodedCardNumberLength);
        }

        public virtual string FormatFacilityCode(long rawNumber)
        {
            return rawNumber.ToString("D" + DecodedFacilityCodeLength);
        }

        private string CreateFullCardNumber(string siteCode, string cardNumber, char separator = '-')
        {
            return string.Format("{0}" + separator + "{1}", siteCode, cardNumber);
        }
    }
}
