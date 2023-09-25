using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthClinicContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new HealthClinicContext();
        }
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.Add(tipoUsuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ctx.Remove(ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
