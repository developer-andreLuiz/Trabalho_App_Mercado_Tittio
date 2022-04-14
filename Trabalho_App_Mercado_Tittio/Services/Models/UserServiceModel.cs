using System;
using System.Collections.Generic;

namespace Trabalho_App_Mercado_Tittio.Services.Models
{
    public class UserServiceModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string img { get; set; }
        public string cpf { get; set; }
        public DateTime nascimento { get; set; }
        public string telefone { get; set; }
        public string aparelhoId { get; set; }
        public double saldo { get; set; }
        public int habilitado { get; set; }
        public UserServiceModel()
        {
            id = 0;
            nome = String.Empty;
            img = String.Empty;
            cpf = String.Empty; 
            nascimento = new DateTime();
            telefone = String.Empty;
            aparelhoId = String.Empty;
            saldo = 0.00;
            habilitado = 1;
        }
    }
}
