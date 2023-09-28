using Microsoft.EntityFrameworkCore;
using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Context
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; } 
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE04-S14; DataBase = healthClinic.codeFirst.tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true", x => x.UseDateOnlyTimeOnly());
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultas>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.NoAction); // Defina o comportamento da operação de exclusão

            modelBuilder.Entity<Consultas>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.NoAction); // Defina o comportamento da operação de exclusão

            // Outras configurações aqui...

            base.OnModelCreating(modelBuilder);
        }
    }
}
