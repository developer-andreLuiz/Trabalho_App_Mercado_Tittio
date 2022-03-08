using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trabalho_App_Mercado_Tittio.Helpers;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        public LoadPage()
        {
            InitializeComponent();
        }

        private async void btnTeste1_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync("email", "developer.andreluiz@gmail.com");
            await Xamarin.Essentials.SecureStorage.SetAsync("password", "J@va0007");
            
            var msg = $"Dados Cadastrados";
            await DisplayAlert("Alert", msg, "OK");
        }

        private async void btnTeste2_Clicked(object sender, EventArgs e)
        {
            string email =string.Empty;
            string password = string.Empty;
            try
            {
                email = await Xamarin.Essentials.SecureStorage.GetAsync("email");
                password = await Xamarin.Essentials.SecureStorage.GetAsync("password");


                var msg = $"Email:{email}{Environment.NewLine}Password:{password}";
                await DisplayAlert("Alert", msg, "OK");
            }
            catch
            {
                var msg = $"Sem dados Cadastrados";
                await DisplayAlert("Alert", msg, "OK");
            }
           
        }

        private void btnTeste3_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}