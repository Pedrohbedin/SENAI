using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext ctx;

        public EventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            BuscarPorId(id).DataEvento = evento.DataEvento;
            BuscarPorId(id).NomeEvento = evento.NomeEvento;
            BuscarPorId(id).Descricao = evento.Descricao;
            BuscarPorId(id).IdTipoEvento = evento.IdTipoEvento;
            BuscarPorId(id).TipoEvento = evento.TipoEvento;
            BuscarPorId(id).Instituicao = evento.Instituicao;

            ctx.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoAchado = ctx.Evento.FirstOrDefault(x => x.IdEvento == id);
                TipoEventoRepository tipoEvento = new TipoEventoRepository();
                InstituicaoRepository instituicao = new InstituicaoRepository();
                eventoAchado.TipoEvento = tipoEvento.BuscarPorId(eventoAchado.IdTipoEvento);
                eventoAchado.Instituicao = instituicao.BuscarPorId(eventoAchado.IdInstituicao);

                return ctx.Evento.FirstOrDefault(x => x.IdEvento == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                ctx.Evento.Add(evento);
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
                ctx.Evento.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            TipoEventoRepository tipoEvento = new TipoEventoRepository();
            InstituicaoRepository instituicao = new InstituicaoRepository();

            foreach (Evento evento in ctx.Evento.ToList())
            {
                evento.TipoEvento = tipoEvento.BuscarPorId(evento.IdTipoEvento);
                evento.Instituicao = instituicao.BuscarPorId(evento.IdInstituicao);
            }

            return ctx.Evento.ToList();
        }
    }
}
