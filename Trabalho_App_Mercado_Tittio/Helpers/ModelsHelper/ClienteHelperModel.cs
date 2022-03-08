using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio.Helpers.ModelsHelper
{
    public  class ClienteHelperModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ClienteHelperModel()
        {
            Id = 0;
            Nome = string.Empty;
        }
    }
}
