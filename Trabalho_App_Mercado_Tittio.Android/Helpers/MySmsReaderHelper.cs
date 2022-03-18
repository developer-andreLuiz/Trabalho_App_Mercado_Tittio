using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_App_Mercado_Tittio.Droid.Helpers;
using Trabalho_App_Mercado_Tittio.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(MySmsReaderHelper))]
namespace Trabalho_App_Mercado_Tittio.Droid.Helpers
{
    internal class MySmsReaderHelper : ISmsReader
    {
        public void GetSmsInbox()
        {
            IntentFilter filter = new IntentFilter();
            filter.AddAction("android.provider.Telephony.SMS_RECEIVED");


            SmsBroadcastReceiverHelper receiver = new SmsBroadcastReceiverHelper();
            Application.Context.RegisterReceiver(receiver, filter);
        }
    }
}