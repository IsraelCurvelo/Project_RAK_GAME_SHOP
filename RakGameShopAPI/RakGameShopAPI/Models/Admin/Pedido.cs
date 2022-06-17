﻿using RakGameShopAPI.Models.Client;
using RakGameShopAPI.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.Admin
{
    public class Pedido : EntidadeDominio
    {
      
        public Cliente Cliente { get; set; }

        [NotMapped]
        public List<Jogo> Jogos { get; set; }

        [NotMapped]
        public Jogo Jogo { get; set; }

        public DateTime DataCompra { get; set; }

        public FormaPagamento FormaPagamento { get; set; }

        public double ValorTotal { get; set; }

        public StatusPedido Status { get; set; }
       

        public Pedido()
        {
            Jogos = new List<Jogo>();
        }

        public Pedido(int id, Cliente cliente, DateTime dataCompra, FormaPagamento formaPagamento, double valorTotal, StatusPedido status,  Jogo jogo)
        {
            Id = id;
            Cliente = cliente;
            DataCompra = dataCompra;
            FormaPagamento = formaPagamento;
            ValorTotal = valorTotal;
            Status = status;            
            Jogos = new List<Jogo>();
            Jogo = Jogo;
        }
    }
}
