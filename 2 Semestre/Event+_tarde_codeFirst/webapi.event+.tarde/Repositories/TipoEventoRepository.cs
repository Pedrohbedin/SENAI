using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext ctx;

        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid Id, TipoEvento tipoEvento)
        {
            BuscarPorId(Id).Titulo = tipoEvento.Titulo;

            ctx.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid Id)
        {
            try
            {
                return ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == Id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoEvento);
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
                ctx.TipoEvento.Remove(BuscarPorId(Id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoEvento> Listar()
        {
            return ctx.TipoEvento.ToList();
        }
    }
}
