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

        /// <inheritdoc/>
        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
        {
            var entidade = BuscarPorId(id);

            if (entidade != null)
            {
                entidade.Descricao = comentarioEvento.Descricao;
                entidade.Exibe = comentarioEvento.Exibe;
                entidade.IdUsuario = comentarioEvento.IdUsuario;
                entidade.Usuario = comentarioEvento.Usuario;
                entidade.IdEvento = comentarioEvento.IdEvento;
                entidade.Evento = comentarioEvento.Evento;

                ctx.SaveChanges();
            }
        }

        /// <inheritdoc/>
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
            try
            {
                ctx.ComentarioEvento.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            return ctx.ComentarioEvento.ToList();
        }
    }
}
