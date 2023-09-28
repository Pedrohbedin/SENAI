using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Agendar(Consultas consulta);
        void Cancelar(Guid id);
        Consultas BuscarPorId(Guid Id);
        void IncluirDescricao(string descricao, Guid Id);
        List<Consultas> ListarPorUsuario(Guid idUsuario);
        List<Consultas> Listar();
    }
}
