using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.Client
{
    public class Usuario : EntidadeDominio
    {
        public String Email { get; set; }

        public String Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Admin { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string email, string senha, DateTime dataCadastro, bool admin)
        {
            Id = id;
            Email = email;
            Senha = senha;
            DataCadastro = dataCadastro;
            Admin = admin;
        }
    }
}
