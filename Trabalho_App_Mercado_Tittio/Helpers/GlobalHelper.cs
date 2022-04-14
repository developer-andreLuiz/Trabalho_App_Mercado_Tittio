using System;
using System.Collections.Generic;

using System.Text;
using Trabalho_App_Mercado_Tittio.Services.Models;

namespace Trabalho_App_Mercado_Tittio.Helpers
{
    class GlobalHelper
    {
        public static GlobalHelper instance = new GlobalHelper();

        public List<CategoryLevel1ServiceModel> listCategoryLevel1 = new List<CategoryLevel1ServiceModel>();

        public List<CategoryLevel2ServiceModel> listCategoryLevel2 = new List<CategoryLevel2ServiceModel>();

        public List<CategoryLevel3ServiceModel> listCategoryLevel3 = new List<CategoryLevel3ServiceModel>();

        public List<CategoryLevel4ServiceModel> listCategoryLevel4 = new List<CategoryLevel4ServiceModel>();

        public List<ProductServiceModel> listProduct = new List<ProductServiceModel>();

        public List<ProductCategoryServiceModel> listProductCategory = new List<ProductCategoryServiceModel>();

        public UserServiceModel User = new UserServiceModel();

        
        public int id_Category_Level1 { get; set; }
        public int id_Category_Level2 { get; set; }
        public int id_Category_Level3 { get; set; }
        public int id_Category_Level4 { get; set; }
    }
}
