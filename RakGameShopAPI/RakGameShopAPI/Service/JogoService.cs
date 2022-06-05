using RakGameShopAPI.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Service
{
    public class JogoService
    {
        public static string ValidarDadosJogo(Jogo jogo)
        {
            if (jogo.Nome != null || jogo.URLFoto != null || jogo.Descricao != null || jogo.Categoria != null
                || jogo.Classificacao != null || jogo.Tamanho != null || jogo.DataLancamento != null || jogo.Desenvolvedora != null)
                return null;
            else
                return "Erro - Dados obrigatórios não digitados";
        }
    }
}
