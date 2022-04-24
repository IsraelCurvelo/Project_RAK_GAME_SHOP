using RakGameShopAPI.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.Admin
{
    public class Jogo
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public Categoria Categoria { get; set; }

        public Classificacao Classificacao { get; set; }

        public String Tamanho { get; set; }

        public String Desenvolvedora { get; set; }

        public DateTime DataLancamento { get; set; }

        public DateTime DataCadastro { get; set; }

        public Status Status { get; set; }

        public String URLFoto { get; set; }

        public double Valor { get; set; }

        public Jogo()
        {

        }

        public Jogo(int id, string nome, string descricao, Categoria categoria, Classificacao classificacao, string tamanho, string desenvolvedora, DateTime dataLancamento, DateTime dataCadastro, Status status, string uRLFoto, double valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Classificacao = classificacao;
            Tamanho = tamanho;
            Desenvolvedora = desenvolvedora;
            DataLancamento = dataLancamento;
            DataCadastro = dataCadastro;
            Status = status;
            URLFoto = uRLFoto;
            Valor = valor;
        }
    }
}
