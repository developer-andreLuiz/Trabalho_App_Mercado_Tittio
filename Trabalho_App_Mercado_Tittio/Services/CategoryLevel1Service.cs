using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Services.Models;

namespace Trabalho_App_Mercado_Tittio.Services
{
    public class CategoryLevel1Service
    {
        public static CategoryLevel1Service instance = new CategoryLevel1Service();
        const string URL = "https://api-mercado-online.azurewebsites.net/api/categoria-nivel-1";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<List<CategoryLevel1ServiceModel>> GetAll()
        {
            string data = URL;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CategoryLevel1ServiceModel>>(content);
            }
            return new List<CategoryLevel1ServiceModel>();
        }
        public async Task<CategoryLevel1ServiceModel> Get(int id)
        {
            string data = URL + "/" + id;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CategoryLevel1ServiceModel>(content);
            }
            return new CategoryLevel1ServiceModel();
        }
        public async Task Create(CategoryLevel1ServiceModel obj)
        {
            string data = URL;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(data, content);//talvez venha o novo id sem busca novamente
        }
        public async Task Update(CategoryLevel1ServiceModel obj)
        {
            string data = URL + "/" + obj.id;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(data, content);
        }
        public async Task Delete(int id)
        {
            string data = URL + "/" + id;
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(data);
        }
    }
}
