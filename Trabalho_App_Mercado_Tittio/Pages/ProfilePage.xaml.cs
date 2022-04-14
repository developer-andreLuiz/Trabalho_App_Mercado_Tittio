using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Places.AutoComplete.Request;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio.Enumerators;
using Trabalho_App_Mercado_Tittio.Helpers;
using Trabalho_App_Mercado_Tittio.Services;
using Trabalho_App_Mercado_Tittio.Services.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
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
        void InsertImageProfileAzure()
        {
            if (GlobalHelper.instance.User.id > 0)
            {
                var obj = imgProfile.Source;
                Type myType = obj.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                foreach (PropertyInfo prop in props)
                {
                    if (prop.Name == "Uri")
                    {
                        object propValue = prop.GetValue(obj, null);
                        break;
                    }
                    if (prop.Name == "File")
                    {
                        object propValue = prop.GetValue(obj, null);
                        byte[] imageData = null;
                        using (var wc = new System.Net.WebClient())
                        {
                            imageData = wc.DownloadData("https://mercadoonline.blob.core.windows.net/usuario/profile.png");
                            var stream = new MemoryStream(imageData);
                            BlobStorageHelper.Upload("usuario", GlobalHelper.instance.User.id.ToString(), stream);
                        }
                        break;
                    }
                    if (prop.Name == "Stream")
                    {
                        object propValue = prop.GetValue(obj, null);
                        StreamImageSource streamImageSource = (StreamImageSource)imgProfile.Source;
                        System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                        Task<Stream> task = streamImageSource.Stream(cancellationToken);
                        Stream stream = task.Result;
                        BlobStorageHelper.Upload("usuario", GlobalHelper.instance.User.id.ToString(), stream);
                        break;
                    }
                }
            }
        }
        async void DisplayDataAsync(string Telephone)
        {
            UserService userService = new UserService();
            await DeviceHelper.SetLogin(Telephone);
            GlobalHelper.instance.User = await userService.Get(Telephone);
            if (GlobalHelper.instance.User.id > 0)
            {
                if (GlobalHelper.instance.User.habilitado == 0)//user disable 
                {
                    App.Current.MainPage = new ErroPage(StatusError.Disabled);
                    return;
                }
                entryName.Text = GlobalHelper.instance.User.nome;
                imgProfile.Source = new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri(GlobalHelper.instance.User.img)
                };
            }
            lblTelephone.Text = Telephone;
        }
        #endregion

        #region Events
        public ProfilePage(string Telephone)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            DisplayDataAsync(Telephone);
        }
        private async void frmImage_Tapped(object sender, EventArgs e)
        {
            try
            {
                string action = await DisplayActionSheet("Abrir com?", "Cancelar", null, "Galeria", "Camera");
                if (action.Equals("Galeria"))
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Não suportado", "Seu dispositivo atualmente não suporta esta funcionalidade", "Ok");
                        return;
                    }
                    var mediaOptions = new PickMediaOptions()
                    {
                        PhotoSize = PhotoSize.Small,
                    };
                    var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
                    if (imgProfile == null)
                    {
                        await DisplayAlert("Erro", "Não foi possível obter a imagem, tente novamente.", "Ok");
                        return;
                    }

                    imgProfile.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                }
                if (action.Equals("Camera"))
                {
                    if (!CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("Não suportado", "Seu dispositivo atualmente não suporta esta funcionalidade", "Ok");
                        return;
                    }
                    var mediaOptions = new StoreCameraMediaOptions()
                    {
                        DefaultCamera = CameraDevice.Front,
                        Name = DateTime.Now.ToString(),
                        Directory = "Mercado Tittio",
                        SaveToAlbum = true,
                        PhotoSize = PhotoSize.Small,
                        AllowCropping = true
                    };
                    var selectedImageFile = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                    if (imgProfile == null)
                    {
                        await DisplayAlert("Erro", "Não foi possível obter a imagem, tente novamente.", "Ok");
                        return;
                    }
                    imgProfile.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
                }
                if (action.Equals("Cancelar"))
                {
                    imgProfile.Source = "profile";
                }
            }
            catch { }

        }
        private async void frmSave_Tapped(object sender, EventArgs e)
        {
            if (entryName.Text.Length > 0)
            {
                UserService userService = new UserService();
                UserServiceModel userServiceModel = new UserServiceModel();
                userServiceModel.nome = entryName.Text;
                userServiceModel.telefone = lblTelephone.Text;
                userServiceModel.aparelhoId = DeviceHelper.GetDeviceID();
                if (GlobalHelper.instance.User.id > 0)
                {
                    GlobalHelper.instance.User.nome = userServiceModel.nome;
                    GlobalHelper.instance.User.telefone = userServiceModel.telefone;
                    GlobalHelper.instance.User.aparelhoId = userServiceModel.aparelhoId;
                    GlobalHelper.instance.User = await userService.Update(GlobalHelper.instance.User);
                }
                else
                {
                    GlobalHelper.instance.User = await userService.Create(userServiceModel);
                }
                if (GlobalHelper.instance.User.id > 0)
                {
                    await DeviceHelper.SetLogin(userServiceModel.telefone);
                }
                InsertImageProfileAzure();
                await DisplayAlert("Sucesso", "Informações Salvas!", "ok");
                App.Current.MainPage = new NavigationPage(new CategoryLevel1Page());
            }
            else
            {
                await DisplayAlert("Erro", "Digite um Nome!", "ok");
            }
        }
        #endregion
    }
}