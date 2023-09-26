using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        void Deletar(Guid Id);
        List<Medico> Listar();
    }
}
