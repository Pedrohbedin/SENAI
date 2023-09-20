using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext ctx;

        public ComentarioEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
        {
            BuscarPorId(id).Descricao = comentarioEvento.Descricao;
            BuscarPorId(id).Exibe = comentarioEvento.Exibe;
            BuscarPorId(id).IdUsuario = comentarioEvento.IdUsuario;
            BuscarPorId(id).Usuario = comentarioEvento.Usuario;
            BuscarPorId(id).IdEvento = comentarioEvento.IdEvento;
            BuscarPorId(id).Evento = comentarioEvento.Evento;

            ctx.SaveChanges();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                return ctx.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                ctx.ComentarioEvento.Add(comentarioEvento);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            ctx.ComentarioEvento.Remove(BuscarPorId(id));
        }

        public List<ComentarioEvento> Listar()
        {
            return ctx.ComentarioEvento.ToList();
        }
    }
}
