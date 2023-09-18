using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Context
{
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuarios { get; set;}
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<TipoEvento> TipoEvento { get; set;}
        public DbSet<PresencaEvento> PresencaEvento { get; set;}
        public DbSet<Instituicao> Instituicao { get; set;}
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE04-S14; DataBase = event+_codeFirst_tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
