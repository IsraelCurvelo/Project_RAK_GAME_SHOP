using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaellShoes.Dal;
using RaellShoes.Data;
using RakGameShopAPI.Models.Admin;
using RakGameShopAPI.Models.Client;
using RakGameShopAPI.Models.NN;
using RakGameShopAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly DAL dal;

        public ClienteController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            dal = new DAL(dbContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("cadastrarcliente")]
        public IActionResult Cadastrar(Cliente cliente)
        {
            try
            {

                string confirmacaoDadosCliente = ClienteService.ValidarDadosCliente(cliente);
                string confirmacaoDadosUser = ClienteService.ValidarDadosUsuario(cliente.Usuario);

                if (confirmacaoDadosCliente != null || confirmacaoDadosUser != null)               
                    return new StatusCodeResult(204);
                

                var confirmacaoBanco = dal.Cadastrar(cliente);

                if(confirmacaoBanco != null)
                    return new StatusCodeResult(204);

                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost("AlterarCliente")]
        public IActionResult Alterar(Cliente cliente)
        {
            try
            {
                string confirmacao = ClienteService.ValidarDadosCliente(cliente);

                if (confirmacao != null)
                    return new StatusCodeResult(204);


                string confirmacaoBanco = dal.ConsultarObjeto(cliente);

                if (confirmacaoBanco != null)
                    return new StatusCodeResult(204);

                string confirmacaoAlteracao = dal.Alterar(cliente);

                if (confirmacaoAlteracao != null)
                    return new StatusCodeResult(204);

                return Ok();

            }             
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("listarclientes")]
        public IActionResult Listar()
        {
            try
            {
                var clientes = dal.Consultar(new Cliente());

                return Ok(clientes);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("deletarcliente")]
        public IActionResult Excluir(Cliente cliente)
        {
            try
            {
                string confirmacao = ClienteService.ValidarDadosCliente(cliente);

                if (confirmacao != null)
                    return new StatusCodeResult(204);


                string confirmacaoBanco = dal.ConsultarObjeto(cliente);

                if (confirmacaoBanco != null)
                    return new StatusCodeResult(204);

                string confirmacaoAlteracao = dal.Excluir(cliente);

                if (confirmacaoAlteracao != null)
                    return new StatusCodeResult(204);

                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("login")]
        public IActionResult Login(Usuario usuario)
        {
            Usuario retornado = dal.Login(usuario);

            if (retornado != null)
            {
                //HttpContext.Session.SetInt32("UsuarioId", clienteLogado.IdCliente);
                return Ok(retornado);
            }                
            else
                return new StatusCodeResult(204);

        }

        [HttpPost("buscarcliente")]
        public IActionResult BuscarClientePeloUsuario(Usuario usuario)
        {
            Cliente cliente = dal.BuscarClientePeloUsuario(usuario);
            if (cliente != null)
                return Ok(cliente);
            else
                return new StatusCodeResult(204);
        }

        [HttpPost("buscarjogoscliente")]
        public IActionResult BuscarJogosdoCliente(Cliente cliente)
        {
            List<ClienteJogo> jogosDoCliente = dal.BuscarJogosdoCliente(cliente);
            List<Jogo> jogos = new List<Jogo>();

            foreach (var item in jogosDoCliente)
            {
                jogos.Add((Jogo)dal.ConsultarId(item));                
            }

            return Ok(jogos);
        }

        [HttpPost("verificarjogosacola")]
        public IActionResult VerificarJogoSacola(Pedido pedido)
        {//201 - se tiver na sacola // 204 - tiver comprado 
            bool confirmaSacolaCliente = dal.VerificarClienteContemSacola(pedido.Cliente);
            bool confirmaJogoNaSacola = dal.VerificarJogoSacolaCliente(pedido);
            bool confirmaJogoComprado = dal.VerificarJogoCompradoCliente(pedido);

            if (confirmaJogoComprado)
                return new StatusCodeResult(204);
            if (confirmaJogoNaSacola)
                return new StatusCodeResult(201);

            return Ok();
        }

        [HttpPost("adicionarjogosacola")]
        public IActionResult AdicionarJogoSacola(Pedido pedido)
        {//201 - se tiver na sacola // 204 - tiver comprado - 202 //erro ao cadastrar ou atualizar
            bool confirmaSacolaCliente = dal.VerificarClienteContemSacola(pedido.Cliente);
            bool confirmaJogoNaSacola = dal.VerificarJogoSacolaCliente(pedido);
            bool confirmaJogoComprado = dal.VerificarJogoCompradoCliente(pedido);

            if(confirmaJogoComprado)
                return new StatusCodeResult(204);
            if(confirmaJogoNaSacola)
                return new StatusCodeResult(201);

            if (!confirmaSacolaCliente)
            {
                Cliente cliente = (Cliente)dal.ConsultarId(pedido.Cliente);
                Jogo jogo = (Jogo)dal.ConsultarId(pedido.Jogo);

                Pedido jogoCliente = new Pedido()
                {
                    Cliente = cliente,
                    Jogo = jogo,
                    DataCompra = DateTime.Now,
                    FormaPagamento = null,
                    Parcelamento = 0,
                    Status = Models.Enum.StatusPedido.Sacola,
                    ValorTotal = 0
                };

                string conf = dal.Cadastrar(jogoCliente);
                if (conf != null)
                    return new StatusCodeResult(202);
                else
                    return Ok();
            }
            else
            {
                JogoNaSacola jogoCliente = new JogoNaSacola()
                {
                    ClienteId = pedido.Cliente.Id,
                    JogoId = pedido.Jogo.Id
                };

                string conf = dal.Cadastrar(jogoCliente);
                if (conf != null)
                    return new StatusCodeResult(202);
                else
                    return Ok();
            }   
        }

        [HttpPost("removersacola")]
        public IActionResult RemoverJogodaSacola(Pedido pedido)
        {
            return Ok();
        }
    }
}
