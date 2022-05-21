using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio.Services.Models
{
    public class ProductServiceModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string pronuncia { get; set; }
        public string img { get; set; }
        public string codigoLoja { get; set; }
        public decimal custoUnitario { get; set; }
        public decimal valorVenda { get; set; }
        public decimal valorPromocao { get; set; }
        public string gramatura { get; set; }
        public string embalagem { get; set; }
        public string peso { get; set; }
        public int igualaProduto { get; set; }
        public int itensCaixa { get; set; }
        public int volume { get; set; }
        public bool validade { get; set; }
        public string informacao { get; set; }
    }
}
