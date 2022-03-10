using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Services.ModelsService;

namespace Trabalho_App_Mercado_Tittio.Services
{
    public class ProdutoService
    {
        public static ProdutoService instancia = new ProdutoService();
        const string URL = "https://api-mercado-online.azurewebsites.net/api/produto";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<List<ProdutoServiceModel>> GetAll()
        {
            string dados = URL;
            HttpClient client  = GetClient();
            var response = await client.GetAsync(dados);
            if(response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProdutoServiceModel>>(content);
            }
            return new List<ProdutoServiceModel>();
        }
        public async Task<ProdutoServiceModel> Get(int id)
        {
            string dados = URL + "/" + id;
            HttpClient client = GetClient();
            var response = await client.GetAsync(dados);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProdutoServiceModel>(content);
            }
            return new ProdutoServiceModel();
        }
        public async Task Create(ProdutoServiceModel obj)
        {
            string dados = URL;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json,Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);//talvez venha o novo id sem busca novamente
        }
        public async Task Update(ProdutoServiceModel obj)
        {
            string dados = URL + "/" + obj.id;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);
        }
        public async Task Delete(int id)
        {
            string dados = URL + "/" + id;
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);
        }
    }
}
