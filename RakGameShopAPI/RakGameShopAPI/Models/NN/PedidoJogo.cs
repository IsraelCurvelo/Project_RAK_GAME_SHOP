﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.NN
{
    public class PedidoJogo : EntidadeDominio
    {
        public int PedidoId { get; set; }
        public int JogoId { get; set; }

        public PedidoJogo()
        {

        }

        public PedidoJogo(int pedidoId, int jogoId)
        {
            PedidoId = pedidoId;
            JogoId = jogoId;
        }
    }
}
