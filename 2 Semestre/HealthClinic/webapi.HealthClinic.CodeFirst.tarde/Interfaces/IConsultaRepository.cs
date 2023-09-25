using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Agendar(Consultas consulta);
        void Cancelar(Guid id);
        List<Consultas> Listar(Guid idUsuario);
    }
}
