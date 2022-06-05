using Microsoft.AspNetCore.Mvc;
using RaellShoes.Dal;
using RaellShoes.Data;
using RakGameShopAPI.Models.Client;
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
    }
}
