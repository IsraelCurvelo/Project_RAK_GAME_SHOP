using Microsoft.EntityFrameworkCore;
using RaellShoes.Data;
using RakGameShopAPI.Models;
using RakGameShopAPI.Models.Admin;
using RakGameShopAPI.Models.Client;
using RakGameShopAPI.Models.NN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaellShoes.Dal
{
    public class DAL : IDAL
    {
        protected readonly DataBaseContext dbContext;
        public DAL(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }        

        public string Cadastrar(EntidadeDominio entidadeDominio)
        {
            try
            {
                dbContext.Add(entidadeDominio);
                dbContext.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        
        public string ConsultarObjeto(EntidadeDominio entidadeDominio)
        {
            switch (entidadeDominio.GetType().Name.ToLower())
            {
                case ("cliente"):
                    if (!dbContext.Cliente.Any(x => x.Id == entidadeDominio.Id))
                    {
                        return "Cliente não encontrado";
                    }
                    return null;

                case ("jogo"):
                    if (!dbContext.Jogo.Any(x => x.Id == entidadeDominio.Id))
                    {
                        return "Jogo não encontrado";
                    }
                    return null;           


                default:
                    return "Tabela ausente";
            }
        }

        public string Alterar(EntidadeDominio entidadeDominio)
        {
            try
            {
                dbContext.Update(entidadeDominio);
                dbContext.SaveChanges();
                return null;
            }
            catch (ApplicationException e)
            {
                return e.Message;
            }
        }

        public string Excluir(EntidadeDominio entidadeDominio)
        {
            try
            {
                dbContext.Remove(entidadeDominio);
                dbContext.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {

            List<EntidadeDominio> resultado = new List<EntidadeDominio>();

            switch (entidadeDominio.GetType().Name.ToLower())
            {
                case ("jogo"):
                    foreach (EntidadeDominio x in dbContext.Jogo.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;
                case ("cliente"):
                    foreach (EntidadeDominio x in dbContext.Cliente.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;                

                default:
                    return null;
            }


        }

        public EntidadeDominio ConsultarId(EntidadeDominio entidadeDominio)
        {
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();

            switch (entidadeDominio.GetType().Name.ToLower())
            {
                case ("clientejogo"):
                    ClienteJogo clienteJogo = (ClienteJogo)entidadeDominio;
                    return dbContext.Jogo.Where(x => x.Id == clienteJogo.JogoId).FirstOrDefault();

                case ("cliente"):
                    Cliente cliente = (Cliente)entidadeDominio;
                    return dbContext.Cliente.Where(x => x.Id == cliente.Id).FirstOrDefault();
                
                case ("jogo"):
                    Jogo jogo = (Jogo)entidadeDominio;
                    return dbContext.Jogo.Where(x => x.Id == jogo.Id).FirstOrDefault();

                default:
                    return null;
            }
        }

        public Usuario Login (Usuario usuario)
        {
            if(usuario.Email != null)
            {
                var usuarioBanco = dbContext.Usuario.FirstOrDefault(x => x.Email == usuario.Email);
                if(usuarioBanco != null)
                {
                    if (usuario.Senha.Equals(usuarioBanco.Senha))
                        return usuarioBanco;
                    else
                        return null;
                }
                else
                    return null;                
            }
            else           
                return null;          
            
        }

        public Cliente BuscarClientePeloUsuario(Usuario usuario)
        {
            return dbContext.Cliente
                .Include(x=> x.Usuario)
                .Where(x => x.Usuario.Id == usuario.Id).FirstOrDefault();
        }

        public List<ClienteJogo> BuscarJogosdoCliente(Cliente cliente)
        {            
            return dbContext.ClienteJogo.Where(x=> x.ClienteId == cliente.Id).ToList();
        }

        public bool VerificarClienteContemSacola(Cliente cliente)
        {
            Pedido pedido = dbContext.Pedido.Where(x => x.Cliente.Id == cliente.Id 
            && x.Status == RakGameShopAPI.Models.Enum.StatusPedido.Sacola).FirstOrDefault();

            if (pedido != null) 
                return true;
            else 
                return false;
        }

        public bool VerificarJogoSacolaCliente(Pedido pedido)
        {
            bool confirmaSacola = VerificarClienteContemSacola(pedido.Cliente);
            if (confirmaSacola)
            {
                JogoNaSacola jogoSacola = dbContext.JogoNaSacola.Where(x => x.JogoId == pedido.Jogo.Id 
                && x.ClienteId == pedido.Cliente.Id).FirstOrDefault();

                if (jogoSacola != null)
                    return true;
                else
                    return false;
            }
            
            return false;
        }

        public bool VerificarJogoCompradoCliente(Pedido pedido)
        {
            ClienteJogo clienteJogo = dbContext.ClienteJogo.Where(x => x.ClienteId == pedido.Cliente.Id
            && x.JogoId == pedido.Jogo.Id).FirstOrDefault();

            if (clienteJogo != null)
                return true;
            else
                return false;
        }

        public List<JogoNaSacola> RemoverJogoDaSacola(JogoNaSacola jogoNaSacola)
        {
            return dbContext.JogoNaSacola.Where(x => x.JogoId == jogoNaSacola.JogoId && x.ClienteId == jogoNaSacola.ClienteId).ToList();
        }

        public Pedido BuscarSacolaCliente(Cliente cliente)
        {
            return dbContext.Pedido.Where(x => x.Cliente.Id == cliente.Id 
            && x.Status == RakGameShopAPI.Models.Enum.StatusPedido.Sacola).FirstOrDefault();
        }

        public List<JogoNaSacola> BuscarJogosdoClienteNaSacola(Cliente cliente)
        {
            return dbContext.JogoNaSacola.Where(x => x.ClienteId == cliente.Id).ToList();
        }

        public JogoNaSacola ConsultarJogoNaSacola(JogoNaSacola jogoNaSacola)
        {
            return dbContext.JogoNaSacola.Where(x => x.ClienteId == jogoNaSacola.ClienteId && x.JogoId == jogoNaSacola.JogoId).FirstOrDefault();
        }
        public List<Pedido> BuscarPedidosDoCliente(Cliente cliente)
        {
            return dbContext.Pedido.Include(x=> x.FormaPagamento).Include(x=> x.FormaPagamento.Cartao).Where(x => x.Cliente.Id == cliente.Id && x.Status == RakGameShopAPI.Models.Enum.StatusPedido.PedidoFinalizado).ToList();
        }
        
        public List<ClienteJogo> BuscarPedidosDoClienteJogos(Cliente cliente)
        {
            return dbContext.ClienteJogo.Where(x => x.ClienteId == cliente.Id).ToList();
        }
    }
}
