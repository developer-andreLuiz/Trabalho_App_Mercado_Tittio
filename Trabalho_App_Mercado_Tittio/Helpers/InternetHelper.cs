using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Trabalho_App_Mercado_Tittio.Helpers
{
    public static class InternetHelper
    {
        public static bool InternetIsOn()
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
    }
}
