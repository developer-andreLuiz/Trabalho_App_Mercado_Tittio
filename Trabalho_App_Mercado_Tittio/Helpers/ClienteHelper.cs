using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Helpers.ModelsHelper;

namespace Trabalho_App_Mercado_Tittio.Helpers
{
    public static class ClienteHelper
    {
        public static ClienteHelperModel Cliente { get; private set; }
        

        public static async Task<bool> GetLogin()
        {
            Cliente = new ClienteHelperModel();
            string Id = await Xamarin.Essentials.SecureStorage.GetAsync("Id");
            string Nome = await Xamarin.Essentials.SecureStorage.GetAsync("Nome");
            if (Id.Length>0 && int.TryParse(Id,out int A) && Nome.Length > 0)
            {
                Cliente.Id = A;
                Cliente.Nome = Nome;
                return true;
            }
            return false;
        }
        public static async Task<bool> SetLogin(int Id , string Nome)
        {
            if (Id > 0 && Nome.Length > 0)
            {
                Cliente.Id = Id;
                Cliente.Nome = Nome;
                await Xamarin.Essentials.SecureStorage.SetAsync("Id", Cliente.Id.ToString());
                await Xamarin.Essentials.SecureStorage.SetAsync("Nome", Cliente.Nome);
                return true;
            }
           
            return false;
        }
        public static void LimparDados()
        {
            Xamarin.Essentials.SecureStorage.RemoveAll();
        }

        /*
            set
            await Xamarin.Essentials.SecureStorage.SetAsync("email", "developer.andreluiz@gmail.com");
            await Xamarin.Essentials.SecureStorage.SetAsync("password", "J@va0007");
         
            get
            email = await Xamarin.Essentials.SecureStorage.GetAsync("email");
            password = await Xamarin.Essentials.SecureStorage.GetAsync("password");

            Xamarin.Essentials.SecureStorage.RemoveAll();
         */
    }
}
