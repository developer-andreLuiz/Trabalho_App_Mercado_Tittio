using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Helpers;
using Trabalho_App_Mercado_Tittio.Services;
using Trabalho_App_Mercado_Tittio.Services.ModelsService;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaNivel1Page : ContentPage
    {
        public CategoriaNivel1Page()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void btnEvento_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryNome.Text))
            {
                string nome = entryNome.Text.ToUpper();
                ClienteHelper.SetLogin(1, nome);
                ClienteService clienteService = new ClienteService();
                GlobalHelper.instancia.Cliente = await clienteService.Get(1);
                GlobalHelper.instancia.Cliente.nome = nome;
                GlobalHelper.instancia.Cliente.aparelhoId = DeviceHelper.DeviceID;
                await clienteService.Update(GlobalHelper.instancia.Cliente);
                entryNome.Text = string.Empty;
                await DisplayAlert("Alerta", "Dados Inseridos", "OK");
            }
            else
            {
                await DisplayAlert("Alerta", "Digite um Nome", "OK");
            }
        }
        private async void btnExibirDados_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alerta", GlobalHelper.instancia.Cliente.nome, "OK");
        }
        private async void btnLimparDados_Clicked(object sender, EventArgs e)
        {
            GlobalHelper.instancia.Cliente = new ClienteServiceModel();
            ClienteHelper.LimparDados();
            await DisplayAlert("Alerta", "Dados Limpos", "OK");
        }

       

       
    }
}