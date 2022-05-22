using RakGameShopAPI.Models.Admin;
using RakGameShopAPI.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.Client
{
    public class Cliente : EntidadeDominio
    {

        public String Nome { get; set; }

        public String Apelido { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public Status Status { get; set; }

        public String CPF { get; set; }

        public String Telefone { get; set; }

        public Usuario Usuario { get; set; }

        public List<Jogo> Jogos { get; set; }

        public List<Cartao> Cartoes { get; set; }

        public Cliente()
        {
            Jogos = new List<Jogo>();
            Cartoes = new List<Cartao>();
        }

        public Cliente(int id, string nome, string apelido, DateTime dataNascimento, DateTime dataCadastro, Status status, string cPF, string telefone, Usuario usuario)
        {
            Id = id;
            Nome = nome;
            Apelido = apelido;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            Status = status;
            CPF = cPF;
            Telefone = telefone;
            Usuario = usuario;
            Jogos = new List<Jogo>();
            Cartoes = new List<Cartao>();
        }
    }
}
