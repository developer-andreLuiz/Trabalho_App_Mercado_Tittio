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
using Xamarin.Forms;
using Trabalho_App_Mercado_Tittio.Interfaces;
using static Android.Provider.Settings;
using Trabalho_App_Mercado_Tittio.Droid.Helpers;

[assembly: Dependency(typeof(DeviceHelper))]
namespace Trabalho_App_Mercado_Tittio.Droid.Helpers
{
    public class DeviceHelper : IDeviceInfo
    {
        public string GetDeviceID()
        {
            var context = Android.App.Application.Context;
            string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);
            return id;
        }
    }
}