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
    public class UserService
    {
        public static UserService instance = new UserService();
        const string URL = "https://api-mercado-online.azurewebsites.net/api/usuario";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<List<UserServiceModel>> GetAll()
        {
           
            string data = URL;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UserServiceModel>>(content);
            }
            return new List<UserServiceModel>();
        }
        public async Task<UserServiceModel> Get(int id)
        {
            string data = URL + "/id/" + id;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserServiceModel>(content);
            }
            return new UserServiceModel();
        }
        public async Task<UserServiceModel> Get(string telephone)
        {
            string data = URL + "/telefone/" + telephone;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserServiceModel>(content);
            }
            return new UserServiceModel();
        }
        public async Task<UserServiceModel> Create(UserServiceModel obj)
        {
            string data = URL;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(data, content);
            if (response.IsSuccessStatusCode)
            {
                string contentReturn = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserServiceModel>(contentReturn);
            }
            return new UserServiceModel();
        }
        public async Task<UserServiceModel> Update(UserServiceModel obj)
        {
            string data = URL + "/" + obj.id;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(data, content);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string contentResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserServiceModel>(contentResponse);
            }
            return new UserServiceModel();
        }
        public async Task Delete(int id)
        {
            string data = URL + "/" + id;
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(data);
        }
    }
}
