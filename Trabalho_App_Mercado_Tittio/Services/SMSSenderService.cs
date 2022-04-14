using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Services.Models;

namespace Trabalho_App_Mercado_Tittio.Services
{
    public class SMSSenderService
    {
        static string URL = "https://api.smsdev.com.br/v1/send";
        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public static async Task SendCodeAsync(int code, long number)
        {

            SMSSenderServiceModel sms = new SMSSenderServiceModel();
            sms.msg = $"Codigo de verificacao:{code}.{Environment.NewLine}Boas Compras Mercado Tittio";
            sms.number = number;

            string json = JsonConvert.SerializeObject(sms);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(URL, content);//talvez venha o novo id sem busca novamente
        }
        
    }
}
