using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
        void Deletar(Guid Id);
        List<Clinica> Listar();
    }
}
