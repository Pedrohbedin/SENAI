using Microsoft.EntityFrameworkCore;
using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Context
{
    /// <summary>
    /// Classe de contexto do Entity Framework para a aplicação HealthClinic.
    /// </summary>
    public class HealthClinicContext : DbContext
    {
        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade Clinica.
        /// </summary>
        public DbSet<Clinica> Clinica { get; set; }

        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade Consultas.
        /// </summary>
        public DbSet<Consultas> Consultas { get; set; }

        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade Especialidade.
        /// </summary>
        public DbSet<Especialidade> Especialidade { get; set; }

        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade Medico.
        /// </summary>
        public DbSet<Medico> Medico { get; set; }

        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade Paciente.
        /// </summary>
        public DbSet<Paciente> Paciente { get; set; }

        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade Situacao.
        /// </summary>
        public DbSet<Situacao> Situacao { get; set; }

        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade TipoUsuario.
        /// </summary>
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        /// <summary>
        /// Obtém ou define o conjunto de dados para a entidade Usuario.
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Configura as opções de conexão com o banco de dados.
        /// </summary>
        /// <param name="optionsBuilder">Construtor de opções.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE04-S14; DataBase = healthClinic.codeFirst.tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true", x => x.UseDateOnlyTimeOnly());
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Configura o modelo de entidades.
        /// </summary>
        /// <param name="modelBuilder">Construtor de modelo.</param>
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
