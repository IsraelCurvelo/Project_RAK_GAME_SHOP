using RakGameShopAPI.Models.Client;
using RakGameShopAPI.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.Admin
{
    public class FormaPagamento: EntidadeDominio
    {
        public TipoPagamento TipoPagamento { get; set; }       

        public Cartao Cartao { get; set; }

        public string Codigo { get; set; }

        public FormaPagamento()
        {

        }

        public FormaPagamento(TipoPagamento tipoPagamento, Cartao cartao, string codigo)
        {
            TipoPagamento = tipoPagamento;
            Cartao = cartao;
            Codigo = codigo;
        }
    }
}
