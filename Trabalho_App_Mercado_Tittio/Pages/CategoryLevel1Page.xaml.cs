using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Helpers;
using Trabalho_App_Mercado_Tittio.Services;
using Trabalho_App_Mercado_Tittio.Services.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryLevel1Page : ContentPage
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
        public CategoryLevel1Page()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (GlobalHelper.instance.User.id > 0)
            {
                ImgProfile.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri(GlobalHelper.instance.User.img)
                };
            }

        }
        private void ImgProfile_Tapped(object sender, EventArgs e)
        {
            if (GlobalHelper.instance.User.id > 0)
            {
                PushAsyncWithoutDuplicate(new ProfilePage(GlobalHelper.instance.User.telefone));
            }
            else
            {
                PushAsyncWithoutDuplicate(new CheckSmsPage());
            }
        }
        private void ImgHome_Tapped(object sender, EventArgs e)
        {
        
        }
        private void ImgSearch_Tapped(object sender, EventArgs e)
        {

        }
        private void ImgCart_Tapped(object sender, EventArgs e)
        {
            
        }
        private void ImgConfig_Tapped(object sender, EventArgs e)
        {
           
        }

        #endregion

       
    }
}