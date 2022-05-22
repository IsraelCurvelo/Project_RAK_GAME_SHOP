using RakGameShopAPI.Models.Client;
using RakGameShopAPI.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.Admin
{
    public class Pedido : EntidadeDominio
    {
      
        public Cliente Cliente { get; set; }

        public List<Jogo> Jogos { get; set; }

        public DateTime DataCompra { get; set; }

        public TipoPagamento TipoPagamento { get; set; }

        public double ValorTotal { get; set; }

        public StatusPedido Status { get; set; }

        public int Parcelamento { get; set; }

        public Pedido()
        {
            Jogos = new List<Jogo>();
        }

        public Pedido(int id, Cliente cliente, DateTime dataCompra, TipoPagamento tipoPagamento, double valorTotal, StatusPedido status, int parcelamento)
        {
            Id = id;
            Cliente = cliente;
            DataCompra = dataCompra;
            TipoPagamento = tipoPagamento;
            ValorTotal = valorTotal;
            Status = status;
            Parcelamento = parcelamento;
            Jogos = new List<Jogo>();
        }
    }
}
