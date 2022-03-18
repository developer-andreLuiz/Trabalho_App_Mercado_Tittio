using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Trabalho_App_Mercado_Tittio.Helpers;
using Trabalho_App_Mercado_Tittio.Services;
using Trabalho_App_Mercado_Tittio.Services.ModelsService;
using Trabalho_App_Mercado_Tittio.Enumerators;

namespace Trabalho_App_Mercado_Tittio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage : ContentPage
    {
        float porcentagemBarra = 0;
        float porcentagemAumento = 10;
        uint tempoAnimacao = 1000;
        
        ProdutoService produtoService;
        ClienteService clienteService;
        ProdutoCategoriaService produtoCategoriaService;
        CategoriaNivel1Service categoriaNivel1Service;
        CategoriaNivel2Service categoriaNivel2Service;
        CategoriaNivel3Service categoriaNivel3Service;
        CategoriaNivel4Service categoriaNivel4Service;
       
        bool internet = false;
        bool internetVerificada = false;
        bool produtoVerificado = false;
        bool clienteVerificado = false;
        bool produtoCategoriaVerificado = false;
        bool categoriaNivel1Verificado = false;
        bool categoriaNivel2Verificado = false;
        bool categoriaNivel3Verificado = false;
        bool categoriaNivel4Verificado = false;
        bool loginVerificado = false;

        public LoadPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (internetVerificada == false)
                {
                    Internet();
                    return true;
                }

                if (produtoVerificado == false)
                {
                    ProdutoAsync();
                    return true;
                }
                if (clienteVerificado == false)
                {
                    ClienteAsync();
                    return true;
                }
                if (produtoCategoriaVerificado == false)
                {
                    ProdutoCategoriaAsync();
                    return true;
                }
                if (categoriaNivel1Verificado == false)
                {
                    CategoriNivel1Async();
                    return true;
                }
                if (categoriaNivel2Verificado == false)
                {
                    CategoriNivel2Async();
                    return true;
                }
                if (categoriaNivel3Verificado == false)
                {
                    CategoriNivel3Async();
                    return true;
                }
                if (categoriaNivel4Verificado == false)
                {
                    CategoriNivel4Async();
                    return true;
                }
               
                if (loginVerificado == false)
                {
                    Login();
                    return true;
                }
                return true;
            }
           );
        }
        void Internet()
        {
            internetVerificada = true;
            internet = InternetHelper.InternetIsOn();
            porcentagemBarra += porcentagemAumento;
            lblPorcentagem.Text = porcentagemBarra + "%";
            lblStatus.Text = "Internet Verificada";
            Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            if (internet==false)
            {
                App.Current.MainPage = new ErroPage(StatusError.Internet,"");
               
            }
           
        }
        async Task ProdutoAsync()
        {
            if (internet)
            {
                produtoVerificado = true;
                produtoService = new ProdutoService();
                GlobalHelper.instancia.listaProdutos = await produtoService.GetAll();
                porcentagemBarra += porcentagemAumento;
                lblPorcentagem.Text = porcentagemBarra + "%";
                lblStatus.Text = $"{GlobalHelper.instancia.listaProdutos.Count} Produto Baixado";
               Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            }
        }
        async Task ClienteAsync()
        {
            if (internet)
            {
                clienteVerificado = true;
                clienteService = new ClienteService();
                GlobalHelper.instancia.Cliente = new ClienteServiceModel();
                ClienteHelper.GetLogin();
                if (ClienteHelper.Cliente.Id>0)
                {
                    GlobalHelper.instancia.Cliente = await clienteService.Get(ClienteHelper.Cliente.Id);
                }
                porcentagemBarra += porcentagemAumento;
                lblPorcentagem.Text = porcentagemBarra + "%";
                lblStatus.Text = $"Cliente Verificado";
                Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            }
        }
        async Task ProdutoCategoriaAsync()
        {
            if (internet)
            {
                produtoCategoriaVerificado = true;
                produtoCategoriaService = new ProdutoCategoriaService();
                GlobalHelper.instancia.listaProdutosCategoria = await produtoCategoriaService.GetAll();
                porcentagemBarra += porcentagemAumento;
                lblPorcentagem.Text = porcentagemBarra + "%";
                lblStatus.Text = $"{GlobalHelper.instancia.listaProdutosCategoria.Count} Produto categoria Baixado";
                Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            }
        }
        async Task CategoriNivel1Async()
        {
            if (internet)
            {
                categoriaNivel1Verificado = true;
                categoriaNivel1Service = new CategoriaNivel1Service();
                GlobalHelper.instancia.listaCategoriaNivel1 = await categoriaNivel1Service.GetAll();
                porcentagemBarra += porcentagemAumento;
                lblPorcentagem.Text = porcentagemBarra + "%";
                lblStatus.Text = $"{GlobalHelper.instancia.listaCategoriaNivel1.Count} categorias nivel 1 Baixado";
                Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            }
        }
        async Task CategoriNivel2Async()
        {
            if (internet)
            {
                categoriaNivel2Verificado = true;
                categoriaNivel2Service = new CategoriaNivel2Service();
                GlobalHelper.instancia.listaCategoriaNivel2 = await categoriaNivel2Service.GetAll();
                porcentagemBarra += porcentagemAumento;
                lblPorcentagem.Text = porcentagemBarra + "%";
                lblStatus.Text = $"{GlobalHelper.instancia.listaCategoriaNivel2.Count} categorias nivel 2 Baixado";
                Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            }
        }
        async Task CategoriNivel3Async()
        {
            if (internet)
            {
                categoriaNivel3Verificado = true;
                categoriaNivel3Service = new CategoriaNivel3Service();
                GlobalHelper.instancia.listaCategoriaNivel3 = await categoriaNivel3Service.GetAll();
                porcentagemBarra += porcentagemAumento;
                lblPorcentagem.Text = porcentagemBarra + "%";
                lblStatus.Text = $"{GlobalHelper.instancia.listaCategoriaNivel3.Count} categorias nivel 3 Baixado";
                Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            }
        }
        async Task CategoriNivel4Async()
        {
            if (internet)
            {
                categoriaNivel4Verificado = true;
                categoriaNivel4Service = new CategoriaNivel4Service();
                GlobalHelper.instancia.listaCategoriaNivel4 = await categoriaNivel4Service.GetAll();
                porcentagemBarra += porcentagemAumento;
                lblPorcentagem.Text = porcentagemBarra + "%";
                lblStatus.Text = $"{GlobalHelper.instancia.listaCategoriaNivel4.Count} categorias nivel 4 Baixado";
                Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
            }
        }
        void Login()
        {
            if (internet)
            {
                if (produtoVerificado && clienteVerificado && produtoCategoriaVerificado && categoriaNivel1Verificado && categoriaNivel2Verificado && categoriaNivel3Verificado && categoriaNivel4Verificado)
                {
                    loginVerificado = true;
                    DeviceHelper.GetDeviceID();
                    if (GlobalHelper.instancia.Cliente.id>0)
                    {
                        string nome = GlobalHelper.instancia.Cliente.nome;

                        if (GlobalHelper.instancia.Cliente.habilitado == 0)//erro
                        {

                            ClienteHelper.LimparDados();
                            GlobalHelper.instancia.Cliente = new ClienteServiceModel();
                            App.Current.MainPage = new ErroPage(StatusError.Desabilitado,nome);
                            return;
                        }

                        if (GlobalHelper.instancia.Cliente.aparelhoId.Equals(DeviceHelper.DeviceID) == false)//erro
                        {
                            ClienteHelper.LimparDados();
                            GlobalHelper.instancia.Cliente = new ClienteServiceModel();
                            App.Current.MainPage = new ErroPage(StatusError.Desconectado,nome);
                            return;
                        }
                      
                    }
                    porcentagemBarra =100;
                    lblPorcentagem.Text = porcentagemBarra + "%";
                    lblStatus.Text = $"Pronto para Iniciar";
                    Barra.ProgressTo(porcentagemBarra / 100, tempoAnimacao, Easing.Linear);
                    
                    App.Current.MainPage = new NavigationPage(new CategoriaNivel1Page());
                    return;
                }
            }
        }
    }
}