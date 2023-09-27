using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext ctx;

        public EspecialidadeRepository()
        {
            ctx = new HealthClinicContext();
        }
        public void Cadastrar(Especialidade especialidade)
        {
            ctx.Especialidade.Add(especialidade);
            ctx.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            ctx.Especialidade.Remove(ctx.Especialidade.FirstOrDefault(x => x.IdEspecialidade == Id));
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidade.ToList();
        }
    }
}
