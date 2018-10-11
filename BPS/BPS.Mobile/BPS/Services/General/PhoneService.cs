using BPS.Core.Contracts.Services.General;
using Plugin.Messaging;

namespace BPS.Core.Services.General
{
    public class PhoneService: IPhoneService
    {
        public void MakePhoneCall()
        {
            CrossMessaging.Current.PhoneDialer.MakePhoneCall("5554885002");
        }
    }
}
