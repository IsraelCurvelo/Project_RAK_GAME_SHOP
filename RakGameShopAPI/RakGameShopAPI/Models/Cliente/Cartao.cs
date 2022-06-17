using RakGameShopAPI.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.Client
{
    public class Cartao: EntidadeDominio
    {
        public String NumeroCartao { get; set; }
        public String TitularCartao { get; set; }
        public String CPF { get; set; }
        public String Validade { get; set; }
        public String CVV { get; set; }
        public Status Status { get; set; }
        public int Parcelas { get; set; }
        public Cliente Cliente { get; set; }
        public Cartao()
        {

        }

        public Cartao(int id, string numeroCartao, string titularCartao, string cPF, string validade, string cVV, Status status)
        {
            Id = id;
            NumeroCartao = numeroCartao;
            TitularCartao = titularCartao;
            CPF = cPF;
            Validade = validade;
            CVV = cVV;
            Status = status;
        }
    }
}
