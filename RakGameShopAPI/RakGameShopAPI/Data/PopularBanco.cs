using RakGameShopAPI.Models.Admin;
using RakGameShopAPI.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaellShoes.Data
{
    public class PopularBanco
    {
        private DataBaseContext dbContext;

        public PopularBanco(DataBaseContext context)
        {
            dbContext = context;
        }

        public void Popular()
        {
            if (dbContext.Cliente.Any() || dbContext.Jogo.Any())
                return;            

            Cliente admin = new Cliente
            {
                Nome = "Admin",
                CPF = "123.123.123-12",
                DataCadastro = DateTime.Now,
                DataNascimento = new DateTime(1992, 02, 02),
                Apelido = "Admin",
                Status = RakGameShopAPI.Models.Enum.Status.Ativo,
                Telefone = "11 9999 9999",
                Usuario = new Usuario
                {
                    Admin = true,
                    DataCadastro = DateTime.Now,
                    Email = "admin@rakgameshop.com",
                    Senha = "A123456b@"
                }
            };

            Cliente cliente = new Cliente
            {
                Nome = "Cliente Teste",
                CPF = "123.123.123-12",
                DataCadastro = DateTime.Now,
                DataNascimento = new DateTime(1992, 02, 02),
                Apelido = "Cliente Teste",
                Status = RakGameShopAPI.Models.Enum.Status.Ativo,
                Telefone = "11 9999 9999",
                Usuario = new Usuario
                {
                    Admin = true,
                    DataCadastro = DateTime.Now,
                    Email = "clienteteste@rakgameshop.com",
                    Senha = "A123456b@"
                }
            };

            Jogo jogo1 = new Jogo
            {
                Nome = "Among Us",                
                Descricao = "Jogo de detetive multiplayer",
                Categoria = "Multiplayer",
                Classificacao = "12",
                Tamanho = "1GB",
                Desenvolvedora = "InnerSloth LLC",
                DataLancamento = new DateTime(2016,04,23),
                DataCadastro = DateTime.Now,
                Status = RakGameShopAPI.Models.Enum.Status.Ativo,
                URLFoto = "among_us.jpg",
                Valor = 19.99
            };

            Jogo jogo2 = new Jogo
            {
                Nome = "FIFA 22",
                Descricao = "Jogo de simulação de futebol",
                Categoria = "Esportes",
                Classificacao = "12",
                Tamanho = "60GB",
                Desenvolvedora = "Eletronic Arts",
                DataLancamento = new DateTime(2021, 07, 29),
                DataCadastro = DateTime.Now,
                Status = RakGameShopAPI.Models.Enum.Status.Ativo,
                URLFoto = "fifa_22.jpg",
                Valor = 149.99
            };
            Jogo jogo3 = new Jogo
            {
                Nome = "Grand Theft Auto V",
                Descricao = "Jogo de campanha de mundo aberto",
                Categoria = "Mundo Aberto",
                Classificacao = "18",
                Tamanho = "70GB",
                Desenvolvedora = "Rockstar Games",
                DataLancamento = new DateTime(2014, 04, 29),
                DataCadastro = DateTime.Now,
                Status = RakGameShopAPI.Models.Enum.Status.Ativo,
                URLFoto = "GTA_5.jpg",
                Valor = 99.99
            };
            Jogo jogo4 = new Jogo
            {
                Nome = "Forza Horizon 5",
                Descricao = "Jogo de simulação de corrida",
                Categoria = "Corrida",
                Classificacao = "12",
                Tamanho = "90GB",
                Desenvolvedora = "Microsoft Games",
                DataLancamento = new DateTime(2022, 02, 11),
                DataCadastro = DateTime.Now,
                Status = RakGameShopAPI.Models.Enum.Status.Ativo,
                URLFoto = "forza_horizon_5.jpg",
                Valor = 74.99
            };

            dbContext.AddRange(admin, cliente);
            dbContext.AddRange(jogo1, jogo2, jogo3, jogo4);
            dbContext.SaveChanges();

        }
    }
}
