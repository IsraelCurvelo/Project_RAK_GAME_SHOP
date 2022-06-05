using RakGameShopAPI.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RakGameShopAPI.Service
{
    public class ClienteService
    {
        public static string ValidarDadosCliente(Cliente cliente)
        {
            if (cliente.Nome != null || cliente.Apelido != null || cliente.DataNascimento != null
                || cliente.CPF != null || cliente.Telefone != null)
                return null;
            else
                return "Erro - Dados Obrigatórios não digitados";
        }

        public static string ValidarDadosUsuario(Usuario usuario)
        {
            if (usuario.Email == null || usuario.Senha == null)
                return "Erro - Dados Obrigatórios não digitados";

            var input = usuario.Senha;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMiniMaxChars = new Regex(@".{8,20}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");


            if (!hasLowerChar.IsMatch(input) || !hasUpperChar.IsMatch(input) || !hasMiniMaxChars.IsMatch(input)
                || !hasNumber.IsMatch(input) || !hasSymbols.IsMatch(input))
                return "CARACTERES OBRIGATÓRIOS NÃO DIGITADOS";

            return null;
        }


    }
}
