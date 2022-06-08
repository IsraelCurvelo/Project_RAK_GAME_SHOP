using RakGameShopAPI.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RakGameShopAPI.Models.Client
{
    public class Sacola : EntidadeDominio
    {
        public Cliente Cliente { get; set; }
        public double ValorTotal { get; set; }
        public List<Jogo> Jogos { get; set; }
    }
}
