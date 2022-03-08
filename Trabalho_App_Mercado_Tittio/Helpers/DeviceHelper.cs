using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_App_Mercado_Tittio.Interfaces;
using Xamarin.Forms;

namespace Trabalho_App_Mercado_Tittio.Helpers
{
    public static class DeviceHelper
    {
        public static string DeviceID()
        {
            IDeviceInfo device = DependencyService.Get<IDeviceInfo>();
            return device.GetDeviceID();
          
        }
    }
}
