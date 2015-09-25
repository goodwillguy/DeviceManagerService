using Tz.LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TZ.Pad.CommonCardParsers;
using TZ.Pad.CommonCardParsers.Interface;
using TZ.Pad.Configuration;
using TZ.Pad.ServiceModel;
using TZ.ServiceModel;

namespace TZ.API.DeviceManagement
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CardReaderMockUp : SelfHostedWCFSingletonService, ICardReaderService, ICardReadMockUpService
    {
        public override void InitializeService()
        {
            var provider = this.Site.GetService<IMockUpCardReaderProvider>();
            if (provider != null)
            {
                _cardreaders = provider.GetSerialNumbers();
                foreach (string sn in _cardreaders)
                {
                  
                    this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Card reader {0} is added", sn);
                }
                this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "IMockUpDevicesProvider is provided, {0} card readers are added.", _cardreaders.Length);


            }
            else
            {
                this.Site.GetService<ILogger>().SafeLogMessage("CardReaderMockUp", "IMockUpCardReaderProvider is not provided.");
            }
            base.InitializeService();
        }

        private string[] _cardreaders = new String[0];

        protected virtual void OnSwipe(Tz.LockerBank.Common.Interface.SwipeEventArgs e)
        {
            if (this.Swipe != null)
            {
                this.Swipe(this, e);
            }
        }

        public event EventHandler<Tz.LockerBank.Common.Interface.SwipeEventArgs> Swipe;

        #region ICardReadMockUpService Members


        void ICardReadMockUpService.Swipe(string rfid, string reader)
        {

            var siteCodeService = this.Site.GetService<ISiteCodeService>();
            var cardReaderConversionService = Site.GetRequiredService<ICardReaderFinder>().GetKioskCardreader();

            if(cardReaderConversionService != null)
            {
                rfid = cardReaderConversionService.EncodeToCardMockup(rfid);
            }
           
            this.OnSwipe(new Tz.LockerBank.Common.Interface.SwipeEventArgs() { RFID = rfid, SerialNumber = reader });
        }

        string[] ICardReadMockUpService.GetReaders()
        {
            return this._cardreaders;
        }

        void ICardReaderService.OnSwipe(Tz.LockerBank.Common.Interface.SwipeEventArgs args)
        {
            throw new NotImplementedException();
        }

        //private const long wpSerialNumber = 959447040;
        //private string ConvertStringToHex(string asciiString)
        //{
        //    string hex = string.Empty;
        //    long result;
        //    if (long.TryParse(asciiString, System.Globalization.NumberStyles.None, CultureInfo.InvariantCulture, out result))
        //    {
        //        hex = (result + wpSerialNumber).ToString("X");
        //    }
        //    return hex;
        //}
        #endregion
    }







}
