using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Enumerators;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErroPage : ContentPage
    {
        StatusError statusError; 
        public ErroPage(StatusError erro,string nome)
        {
            InitializeComponent();
            statusError = erro;
           
            if (statusError == StatusError.Internet)
            {
                lblStatus.Text = $"Você esta sem Internet";
                btnTentarNovamente.Text = "Tentar Novamente";
                return;
            }
            if (statusError == StatusError.Desabilitado)
            {
                lblStatus.Text = $"Lamentamos {nome}, sua conta esta Bloqueada {Environment.NewLine}Desconectado";
                btnTentarNovamente.Text = "Suporte";
                return;
            }
            if (statusError == StatusError.Desconectado)
            {
                lblStatus.Text = $"Lamentamos {nome}, você foi desconectado houve um login em outro Dispositivo";
                btnTentarNovamente.Text = "Ir as Compras";
                return;
            }
           
        }

        private async void btnTentarNovamente_Clicked(object sender, EventArgs e)
        {
            if (statusError== StatusError.Internet)
            {
                App.Current.MainPage = new LoadPage();
                return;
            }
            if (statusError == StatusError.Desabilitado)
            {
                await DisplayAlert("Alerta", "Abrir WhatsApp", "OK");
                return;
            }
            if (statusError == StatusError.Desconectado)
            {
                App.Current.MainPage = new NavigationPage(new CategoriaNivel1Page());
                return;
            }

        }
    }
}