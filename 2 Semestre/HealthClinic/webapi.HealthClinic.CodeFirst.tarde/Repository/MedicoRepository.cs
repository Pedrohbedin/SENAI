using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext ctx;
        public MedicoRepository()
        {
            ctx = new HealthClinicContext();
        }

        public Medico BuscarPorId(Guid Id)
        {
            return ctx.Medico.FirstOrDefault(x => x.IdUsuario == Id);
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);
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
                ctx.Medico.Remove(ctx.Medico.FirstOrDefault(x => x.IdMedico == Id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Medico> Listar()
        {
            try
            {
                return ctx.Medico.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
