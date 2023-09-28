using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);
        void Deletar(Guid Id);
        List<Especialidade> Listar();
        Especialidade BuscarPorId(Guid Id);
        void Atualizar(Especialidade especialidade, Guid Id);
    }
}
