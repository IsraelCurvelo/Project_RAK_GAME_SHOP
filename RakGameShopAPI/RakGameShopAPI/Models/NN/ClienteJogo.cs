using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Models.NN
{
    public class ClienteJogo : EntidadeDominio
    {
        public int ClienteId { get; set; }
        public int JogoId { get; set; }

        public ClienteJogo()
        {
                
        }

        public ClienteJogo(int clienteId, int jogoId)
        {
            ClienteId = clienteId;
            JogoId = jogoId;
        }
    }
}
