using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoogleApi;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Response;
using Xamarin.Essentials;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindAddressPage : ContentPage
    {
        #region Variables
        string txtInitial=string.Empty;
        #endregion

        #region Functions
        string FindAddress(string find)
        {
            
            return null;
        }
        #endregion

        #region Events
        public FindAddressPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            txtInitial =lblAddress.Text;
        }
        private void entryAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (entryAddress.Text.Length > 0)
            {
                var request = new PlacesAutoCompleteRequest()
                {
                    Key = "AIzaSyDwiRZBtZQs4tnogGw8q_Qt1wIX-noWHx4",
                    Input = entryAddress.Text,
                    Language = GoogleApi.Entities.Common.Enums.Language.PortugueseBrazil

                };

                lblAddress.Text = "";
                PlacesAutoCompleteResponse placesAutoCompleteRequest = GooglePlaces.AutoComplete.Query(request);
                foreach (var a in placesAutoCompleteRequest.Predictions)
                {
                    lblAddress.Text = lblAddress.Text + Environment.NewLine + a.Description;
                }
            }
        }
        private void btnClearAddress_Clicked(object sender, EventArgs e)
        {
            entryAddress.Text = string.Empty;
            lblAddress.Text = txtInitial;
        }
        private async void OpenGps_Tapped(object sender, EventArgs e)
        {
            var localizacao = await Geolocation.GetLocationAsync();
            if (localizacao != null)
            {
                Location location = new Location(localizacao.Latitude, localizacao.Longitude);

                await Map.OpenAsync(location);
            }

           

        }

       
        #endregion


    }
}