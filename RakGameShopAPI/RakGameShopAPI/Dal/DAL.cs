using Microsoft.EntityFrameworkCore;
using RaellShoes.Data;
using RakGameShopAPI.Models;
using RakGameShopAPI.Models.Admin;
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
            throw new NotImplementedException();
        }

        

       
    }
}
