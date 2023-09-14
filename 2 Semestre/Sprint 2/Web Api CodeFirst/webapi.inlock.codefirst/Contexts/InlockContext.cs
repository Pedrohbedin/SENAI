using webapi.inlock.codefirst.Domains;
using Microsoft.EntityFrameworkCore;

namespace webapi.inlock.codefirst.Contexts
{
    public class InlockContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE04-S14; DataBase = inlock_games_codeFirst_tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
