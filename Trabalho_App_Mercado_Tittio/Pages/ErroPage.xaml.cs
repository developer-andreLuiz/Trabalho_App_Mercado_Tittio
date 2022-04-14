using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Enumerators;
using Trabalho_App_Mercado_Tittio.Helpers;
using Trabalho_App_Mercado_Tittio.Services.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErroPage : ContentPage
    {
        StatusError statusError; 
        string name = string.Empty;
        public ErroPage(StatusError erro)
        {
            InitializeComponent();
            statusError = erro;
           
            if (statusError == StatusError.Internet)
            {
                lblStatus.Text = $"Você esta sem Internet";
                btnTryAgain.Text = "Tentar Novamente";
                return;
            }
            if (statusError == StatusError. Disabled)
            {
                lblStatus.Text = $"Lamentamos {name}, sua conta esta Bloqueada {Environment.NewLine}Desconectado";
                btnTryAgain.Text = "Suporte";
                return;
            }
            if (statusError == StatusError. Disconnect)
            {
                lblStatus.Text = $"Lamentamos {name}, você foi desconectado houve um login em outro Dispositivo";
                btnTryAgain.Text = "Ir as Compras";
                return;
            }
           
        }

        private void btnTryAgain_Clicked(object sender, EventArgs e)
        {
            if (statusError == StatusError.Internet)
            {
                App.Current.MainPage = new LoadPage();
                return;
            }
            if (statusError == StatusError.Disabled)
            {
                string message = $"Oi,eu sou o {GlobalHelper.instance.User.nome}, e minha conta esta Bloqueada, preciso de ajuda.";
                DeviceHelper.OpenWhatsApp("+5521987788440", message);
                return;
            }
            if (statusError == StatusError.Disconnect)
            {
                DeviceHelper.DataClear();
                GlobalHelper.instance.User = new UserServiceModel();
                App.Current.MainPage = new NavigationPage(new CategoryLevel1Page());
                return;
            }

        }
    }
}