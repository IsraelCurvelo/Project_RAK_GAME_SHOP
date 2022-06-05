﻿using Microsoft.AspNetCore.Mvc;
using RaellShoes.Dal;
using RaellShoes.Data;
using RakGameShopAPI.Models.Admin;
using RakGameShopAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RakGameShopAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly DAL dal;

      
        public AdminController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            dal = new DAL(dbContext);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("cadastrarjogo")]
        public IActionResult CadastrarJogo(Jogo jogo)
        {
            try
            {
               string confirmacaoDadosJogo = JogoService.ValidarDadosJogo(jogo);

                if (confirmacaoDadosJogo != null)
                    return new StatusCodeResult(204);                
                
                string confirmacao = dal.Cadastrar(jogo);

                return Ok();

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("buscarjogos")]
        public IActionResult BuscarJogos()
        {
            try
            {
                var jogos = dal.Consultar(new Jogo());

                return Ok(jogos);

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
