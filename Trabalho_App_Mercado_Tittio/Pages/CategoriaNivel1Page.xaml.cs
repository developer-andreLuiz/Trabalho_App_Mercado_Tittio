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
        #region Variables
        #endregion

        #region Functions
        private void PushAsyncWithoutDuplicate(Page page)
        {
            if (Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].GetType() != page.GetType())
            {
                Navigation.PushAsync(page);
            }
        }
        #endregion

        #region Events
        public CategoriaNivel1Page()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (GlobalHelper.instancia.Cliente.id > 0)
            {
                ImageSource image = ImageSource.FromUri(new Uri($"https://mercadoonline.blob.core.windows.net/cliente/{GlobalHelper.instancia.Cliente.id}.jpg"));
                btnImgProfile.Source = image;
            }
        }

        private void btnImgHome_Clicked(object sender, EventArgs e)
        {

        }
        private void btnImgSearch_Clicked(object sender, EventArgs e)
        {

        }
        private void btnImgProfile_Clicked(object sender, EventArgs e)
        {
            if (GlobalHelper.instancia.Cliente.id > 0)
            {
                PushAsyncWithoutDuplicate(new ProfilePage());
            }
            else
            {
                PushAsyncWithoutDuplicate(new CheckSmsPage());
            }
        }
       
        private void btnImgConfig_Clicked(object sender, EventArgs e)
        {
            PushAsyncWithoutDuplicate(new ProfilePage());
        }
        private void btnImgCart_Clicked(object sender, EventArgs e)
        {

        }

        #endregion

        
    }
}