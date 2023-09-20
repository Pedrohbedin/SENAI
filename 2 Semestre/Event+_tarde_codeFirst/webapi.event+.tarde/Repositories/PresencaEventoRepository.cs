using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext ctx;

        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            BuscarPorId(id).IdEvento = presencaEvento.IdEvento;
            BuscarPorId(id).IdUsuario = presencaEvento.IdUsuario;
            BuscarPorId(id).Situacao = presencaEvento.Situacao;

            ctx.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                return ctx.PresencaEvento.FirstOrDefault(x => x.IdPresencaEvento == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            try
            {
                ctx.PresencaEvento.Add(presencaEvento);
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
                ctx.PresencaEvento.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PresencaEvento> Listar()
        {
            return ctx.PresencaEvento.ToList();
        }
    }
}
