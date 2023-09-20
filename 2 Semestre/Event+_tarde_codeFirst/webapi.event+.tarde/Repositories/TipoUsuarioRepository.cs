using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            BuscarPorId(id).Titulo = tipoUsuario.Titulo;

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {

            try
            {
                TipoUsuario tipoUsuarioAchado = ctx.TipoUsuarios.FirstOrDefault(x => x.IdTipoUsuario == id)!;

                return tipoUsuarioAchado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuarios.Add(tipoUsuario);
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
                ctx.TipoUsuarios.Remove(BuscarPorId(id));

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar() => ctx.TipoUsuarios.ToList();
    }
}
