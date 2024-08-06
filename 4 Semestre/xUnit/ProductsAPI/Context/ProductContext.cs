using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domains;
using System.Collections.Generic;

namespace ProductsAPI.Context
{
    public class ProductsContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE01-S21; DataBase = ProductsAPI_Tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
