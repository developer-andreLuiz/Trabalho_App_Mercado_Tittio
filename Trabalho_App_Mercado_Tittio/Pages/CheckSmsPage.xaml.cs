using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Helpers;
using Trabalho_App_Mercado_Tittio.Interfaces;
using Trabalho_App_Mercado_Tittio.Services;
using Trabalho_App_Mercado_Tittio.Services.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckSmsPage : ContentPage
    {
        #region Variables
        bool timer = false;
        static int timerCountMax = 30;
        int timerCount = timerCountMax;
        bool CanSend = true;
        string Telephone= string.Empty;
        int code = 0;
        #endregion

        #region Functions
        private void PushAsyncWithoutDuplicate(Page page)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != page.GetType())
            {
                Navigation.PushAsync(page);
            }
        }
        async void SendSMS()
        {
            Random random = new Random();
            code = random.Next(100000, 999999);

            string txt = entryTelephone.Text.Trim();
            long telephone = 0;
            if (long.TryParse(txt, out telephone) && txt.Length == 11)
            {
                Telephone = txt;
                await SMSSenderService.SendCodeAsync(code, telephone);
                DependencyService.Get<IKeyboard>().HideKeyboard();

                var p = await Permissions.CheckStatusAsync<Permissions.Sms>();
                if (p != PermissionStatus.Granted)
                {
                    p = await Permissions.RequestAsync<Permissions.Sms>();
                }
                if (p == PermissionStatus.Granted)
                {
                    Xamarin.Forms.DependencyService.Get<ISmsReader>().GetSmsInbox();
                }
                btnSendSMS.IsVisible = false;
                CanSend = false;
                gridCheckSMS.IsVisible = true;
                timer = true;
            }
            else
            {
                await DisplayAlert("Erro", "Número Incorreto!", "OK");
            }
        }
        async void CheckCode()
        {
            string txt = entryCode.Text.Trim();
            if (txt.Equals(code.ToString()))
            {
                PushAsyncWithoutDuplicate(new ProfilePage(Telephone));
            }
            else
            {
                await DisplayAlert("Erro", "Código Errado!", "OK");
                entryCode.Text = String.Empty;
            }
        }
        #endregion

        #region Events
        public CheckSmsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (timer)
                {
                    timerCount--;
                    if (timerCount>9)
                    {
                        lblTime.Text = $"00:{timerCount}";
                    }
                    else
                    {
                        lblTime.Text = $"00:0{timerCount}";
                    }
                    if (timerCount==0)
                    {
                        timer = false;
                        timerCount = timerCountMax;
                        btnSendSMS.IsVisible = true;
                    }
                    
                }
                return true;
            }
            );
            MessagingCenter.Subscribe<List<string>>(this, "MyMessage", (expense) =>
            {
                List<string> mylist = expense as List<string>;
                string allText = "";
                foreach (string item in mylist)
                {
                    allText += item + "  ";
                }
                if (allText.ToUpper().Contains("MERCADO TITTIO") && allText.ToUpper().Contains("CODIGO DE VERIFICACAO"))
                {
                    entryCode.Text = allText.Replace("Codigo de verificacao:","").Substring(0, 6);
                    CheckCode();
                }
            });
        }
        private void entryTelephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CanSend)
            {
                string txt = entryTelephone.Text;
                if (txt.Length == 11)
                {
                    btnSendSMS.IsVisible = true;
                }
                else
                {
                    btnSendSMS.IsVisible = false;
                }
            }
        }
        private void btnSendSMS_Tapped(object sender, EventArgs e)
        {
            SendSMS();
        }
        private void btnCheckSMS_Tapped(object sender, EventArgs e)
        {
            CheckCode();
        }
        #endregion
    }
}