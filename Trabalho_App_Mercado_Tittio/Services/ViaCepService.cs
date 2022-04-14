using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Trabalho_App_Mercado_Tittio.Services.Models;

namespace Trabalho_App_Mercado_Tittio.Services
{
    public class ViaCepService
    {
        private static string URL = "https://viacep.com.br/ws/{0}/json/";
        public static ViaCepServiceModel GetAddress(string cep)
        {
            try
            {
                string newURL = string.Format(URL, cep);
                WebClient wc = new WebClient();
                string content = wc.DownloadString(newURL);
                ViaCepServiceModel end = JsonConvert.DeserializeObject<ViaCepServiceModel>(content);
                return end;
            }
            catch
            {
                return new ViaCepServiceModel();
            }
        }
    }
}
