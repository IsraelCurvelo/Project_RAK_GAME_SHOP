using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.NN
{
    public class JogoNaSacola : EntidadeDominio
    {
        public int ClienteId { get; set; }
        public int JogoId { get; set; }

        public JogoNaSacola()
        {

        }

        public JogoNaSacola(int pedidoId, int jogoId)
        {
            ClienteId = pedidoId;
            JogoId = jogoId;
        }
    }
}
