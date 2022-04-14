using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio.Services.Models
{
    public class CategoryLevel4ServiceModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string img { get; set; }
        public int ordem { get; set; }
        public int categoriaNivel1 { get; set; }
        public int categoriaNivel2 { get; set; }
        public int categoriaNivel3 { get; set; }
    }
}
