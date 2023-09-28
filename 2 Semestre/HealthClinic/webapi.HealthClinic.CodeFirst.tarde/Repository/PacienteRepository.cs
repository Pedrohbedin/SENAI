using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthClinicContext ctx;
        public PacienteRepository()
        {
            ctx = new HealthClinicContext();
        }

        public Paciente BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {;
                paciente.Usuario = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == paciente.idUsuario);
                ctx.Paciente.Add(paciente);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                ctx.Paciente.Remove(ctx.Paciente.FirstOrDefault(x => x.IdPaciente == Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paciente> Listar()
        {
            try
            {
                foreach(Paciente paciente in ctx.Paciente.ToList())
                {
                    paciente.Usuario = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == paciente.idUsuario);
                }
                return ctx.Paciente.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
