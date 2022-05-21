using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trabalho_App_Mercado_Tittio.Helpers;
using Trabalho_App_Mercado_Tittio.Services;
using Trabalho_App_Mercado_Tittio.Services.Models;
using Trabalho_App_Mercado_Tittio.Enumerators;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        float percentageBar = 0;
        float percentageIncrease = 10;
        uint animationTime = 1000;
        
        bool internetIsOn = false;
        bool internetVerified = false;
        bool productVerified = false;
        bool clientVerified = false;
        bool productCategoryVerified = false;
        bool categoryLevel1Verified = false;
        bool categoryLevel2Verified = false;
        bool categoryLevel3Verified = false;
        bool categoryLevel4Verified = false;
        bool loginVerified = false;

        public LoadPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (internetVerified == false)
                {
                    InternetCheck();
                    return true;
                }

                if (productVerified == false)
                {
                    ProductAsync();
                    return true;
                }
                if (productCategoryVerified == false)
                {
                    ProductCategoryAsync();
                    return true;
                }
                if (categoryLevel1Verified == false)
                {
                    CategoryLevel1Async();
                    return true;
                }
                if (categoryLevel2Verified == false)
                {
                    CategoryLevel2Async();
                    return true;
                }
                if (categoryLevel3Verified == false)
                {
                    CategoryLevel3Async();
                    return true;
                }
                if (categoryLevel4Verified == false)
                {
                    CategoryLevel4Async();
                    return true;
                }
                if (clientVerified == false)
                {
                    UserAsync();
                    return true;
                }
                if (loginVerified == false)
                {
                    Login();
                    return true;
                }

                return true;
            }
           );
        }

        void AnimationBar(string msg,bool finished)
        {
            if (finished)
            {
                percentageBar = 100;
                lblPercentage.Text = percentageBar + "%";
                lblStatus.Text = $"Pronto para Iniciar";
                Bar.ProgressTo(percentageBar / 100, animationTime, Easing.Linear);
            }
            else
            {
                percentageBar += percentageIncrease;
                lblPercentage.Text = percentageBar + "%";
                lblStatus.Text = $"{msg}";
                Bar.ProgressTo(percentageBar / 100, animationTime, Easing.Linear);
            }
        }
        void InternetCheck()
        {
            internetVerified = true;
            internetIsOn = DeviceHelper.InternetCheck();
            AnimationBar("Internet Verificada",false);
            if (internetIsOn==false)
            {
                App.Current.MainPage = new ErroPage(StatusError.Internet);
            }
        }
        async Task ProductAsync()
        {
            if (internetIsOn)
            {
                productVerified = true;
                ProductService productService = new ProductService();
                GlobalHelper.instance.listProduct = await productService.GetAll();
                AnimationBar("Produto", false);
            }
        }
        async Task ProductCategoryAsync()
        {
            if (internetIsOn)
            {
                productCategoryVerified = true;
                ProductCategoryService productCategoryService = new ProductCategoryService();
                GlobalHelper.instance.listProductCategory = await productCategoryService.GetAll();
                AnimationBar("Produto Categoria", false);
            }
        }
        async Task CategoryLevel1Async()
        {
            if (internetIsOn)
            {
                categoryLevel1Verified = true;
                CategoryLevel1Service categoryLevel1Service = new CategoryLevel1Service();
                GlobalHelper.instance.listCategoryLevel1 = await categoryLevel1Service.GetAll();
                AnimationBar("Categoria Nivel 1", false);
            }
        }
        async Task CategoryLevel2Async()
        {
            if (internetIsOn)
            {
                categoryLevel2Verified = true;
                CategoryLevel2Service categoryLevel2Service = new CategoryLevel2Service();
                GlobalHelper.instance.listCategoryLevel2 = await categoryLevel2Service.GetAll();
                AnimationBar("Categoria Nivel 2", false);
            }
        }
        async Task CategoryLevel3Async()
        {
            if (internetIsOn)
            {
                categoryLevel3Verified = true;
                CategoryLevel3Service categoryLevel3Service = new CategoryLevel3Service();
                GlobalHelper.instance.listCategoryLevel3 = await categoryLevel3Service.GetAll();
                AnimationBar("Categoria Nivel 3", false);
            }
        }
        async Task CategoryLevel4Async()
        {
            if (internetIsOn)
            {
                categoryLevel4Verified = true;
                CategoryLevel4Service categoryLevel4Service = new CategoryLevel4Service();
                GlobalHelper.instance.listCategoryLevel4 = await categoryLevel4Service.GetAll();
                AnimationBar("Categoria Nivel 4", false);
            }
        }
        async Task UserAsync()
        {
            if (internetIsOn)
            {
                clientVerified = true;
                GlobalHelper.instance.User = new UserServiceModel();
                string value = await DeviceHelper.GetLogin();
                if (value.Length > 0)
                {
                    UserService clientService = new UserService();
                    GlobalHelper.instance.User = await clientService.Get(value);
                }
                AnimationBar("Usuario", false);
            }
        }
        void Login()
        {
            if (internetIsOn)
            {
                if (productVerified && clientVerified && productCategoryVerified && categoryLevel1Verified && categoryLevel2Verified && categoryLevel3Verified && categoryLevel4Verified)
                {
                    loginVerified = true;
                    if (GlobalHelper.instance.User.id>0)
                    {
                        string deviceIdLocal = DeviceHelper.GetDeviceID();

                        if (GlobalHelper.instance.User.habilitado == 0)//user disable 
                        {
                            App.Current.MainPage = new ErroPage(StatusError.Disabled);
                            return;
                        }

                        if (GlobalHelper.instance.User.aparelhoId.Equals(deviceIdLocal) == false)//other device
                        {
                            DeviceHelper.DataClear();
                            GlobalHelper.instance.User = new UserServiceModel();
                            App.Current.MainPage = new ErroPage(StatusError.Disconnect);
                            return;
                        }
                      
                    }
                    AnimationBar("Pronto", true);
                    App.Current.MainPage = new NavigationPage(new CategoryLevel1Page());
                    return;
                }
            }
        }
    }
}