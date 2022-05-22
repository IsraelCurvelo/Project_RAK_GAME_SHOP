using Microsoft.EntityFrameworkCore;
using RaellShoes.Data;
using RakGameShopAPI.Models;
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

        public string Alterar(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public string Cadastrar(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public EntidadeDominio ConsultarId(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public string Excluir(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }
    }
}
