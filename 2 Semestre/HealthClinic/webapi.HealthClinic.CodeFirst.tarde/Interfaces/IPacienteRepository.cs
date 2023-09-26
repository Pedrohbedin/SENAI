using webapi.HealthClinic.CodeFirst.tarde.Domains;

namespace webapi.HealthClinic.CodeFirst.tarde.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        void Deletar(Guid Id);
        List<Paciente> Listar();
    }
}
