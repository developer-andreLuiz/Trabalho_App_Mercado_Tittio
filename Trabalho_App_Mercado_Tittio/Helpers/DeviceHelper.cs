using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;

namespace Trabalho_App_Mercado_Tittio.Helpers
{
    public static class DeviceHelper
    {
        public static bool InternetCheck()
        {
            try
            {
                using (var client = new WebClient())
                {
                    WebProxy wp = new WebProxy();
                    client.Proxy = wp;
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static string GetDeviceID()
        {
            IDeviceInfo device = DependencyService.Get<IDeviceInfo>();
            return device.GetDeviceID();
        }
        public static async Task<string> GetLogin()
        {
            string value = string.Empty;
            string loginString = await Xamarin.Essentials.SecureStorage.GetAsync("Login");
            if (loginString.Length>0)
            {
               value = loginString;
            }
            return value;
        }
        public static async Task<bool> SetLogin(string telephone)
        {
            DataClear();
            if (telephone.Length > 0)
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("Login", telephone);
                return true;
            }
            return false;
        }
        public static void DataClear()
        {
            Xamarin.Essentials.SecureStorage.RemoveAll();
        }
        public static void OpenWhatsApp(string telephone, string message)
        {
            try
            {
                Chat.Open(telephone, message);
            }
            catch { }
        }
    }
}
