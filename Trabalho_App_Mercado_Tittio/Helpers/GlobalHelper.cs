using System;
using System.Collections.Generic;

using System.Text;
using Trabalho_App_Mercado_Tittio.Services.ModelsService;

namespace Trabalho_App_Mercado_Tittio.Helpers
{
    class GlobalHelper
    {
        public static GlobalHelper instancia = new GlobalHelper();

        public List<CategoriaNivel1ServiceModel> listaCategoriaNivel1 = new List<CategoriaNivel1ServiceModel>();

        public List<CategoriaNivel2ServiceModel> listaCategoriaNivel2 = new List<CategoriaNivel2ServiceModel>();

        public List<CategoriaNivel3ServiceModel> listaCategoriaNivel3 = new List<CategoriaNivel3ServiceModel>();

        public List<CategoriaNivel4ServiceModel> listaCategoriaNivel4 = new List<CategoriaNivel4ServiceModel>();

        public List<ProdutoServiceModel> listaProdutos = new List<ProdutoServiceModel>();

        public List<ProdutoCategoriaServiceModel> listaProdutosCategoria = new List<ProdutoCategoriaServiceModel>();

        public ClienteServiceModel Cliente = new ClienteServiceModel();

        
        public int id_Categoria_Nivel1 { get; set; }
        public int id_Categoria_Nivel2 { get; set; }
        public int id_Categoria_Nivel3 { get; set; }
        public int id_Categoria_Nivel4 { get; set; }
    }
}
