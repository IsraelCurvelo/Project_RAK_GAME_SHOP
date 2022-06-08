using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.NN
{
    public class PedidoJogo : EntidadeDominio
    {
        public int PedidoId { get; set; }
        public int JogoId { get; set; }
    }
}
