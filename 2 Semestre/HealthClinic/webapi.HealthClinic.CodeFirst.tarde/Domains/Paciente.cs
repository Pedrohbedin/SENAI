namespace webapi.HealthClinic.CodeFirst.tarde.Domains
{
    public class Paciente
    {
        public Guid IdPaciente { get; set; }
        public Guid idUsuario { get; set; }
        public Usuario? Usuario { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        //Parei aqui
    }
}
