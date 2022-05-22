﻿using Microsoft.EntityFrameworkCore;
using RakGameShopAPI.Models.Admin;
using RakGameShopAPI.Models.Client;

namespace RaellShoes.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }
       
        public DataBaseContext (DbContextOptions<DataBaseContext> options): base(options) {  }    
   
        public DbSet<Cliente> Cliente { get; set; }  
        
        public DbSet<Usuario> Usuario { get; set; }   
        
        public DbSet<Jogo> Jogo { get; set; }

        public DbSet<Cartao> Cartao { get; set; }       

        public DbSet<Pedido> Pedido { get; set; }        
        
    }
}
