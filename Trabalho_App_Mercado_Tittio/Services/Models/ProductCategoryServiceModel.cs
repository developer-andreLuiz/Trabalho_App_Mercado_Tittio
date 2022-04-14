using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio.Services.Models
{
    public class ProductCategoryServiceModel
    {
        public int id { get; set; }
        public int codigoProduto { get; set; }
        public int categoriaNivel1 { get; set; }
        public int categoriaNivel2 { get; set; }
        public int categoriaNivel3 { get; set; }
        public int categoriaNivel4 { get; set; }
        public int ordem { get; set; }
    }
}
