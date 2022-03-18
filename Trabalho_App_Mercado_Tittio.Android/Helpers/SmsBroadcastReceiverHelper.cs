using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Trabalho_App_Mercado_Tittio.Droid.Helpers
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SmsBroadcastReceiverHelper : BroadcastReceiver
    {
        public SmsBroadcastReceiverHelper()
        {

        }
        public override void OnReceive(Context context, Intent intent)
        {
            var msgs = Telephony.Sms.Intents.GetMessagesFromIntent(intent);

            List<string> msgList = new List<string>();
            foreach (var msg in msgs)
            {
                msgList.Add(msg.DisplayMessageBody);

            }
            MessagingCenter.Send<List<string>>(msgList, "MyMessage");
        }
    }
}