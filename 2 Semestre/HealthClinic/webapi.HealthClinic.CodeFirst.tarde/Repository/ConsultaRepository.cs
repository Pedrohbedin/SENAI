using webapi.HealthClinic.CodeFirst.tarde.Context;
using webapi.HealthClinic.CodeFirst.tarde.Domains;
using webapi.HealthClinic.CodeFirst.tarde.Interfaces;

namespace webapi.HealthClinic.CodeFirst.tarde.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthClinicContext ctx;

        public ConsultaRepository()
        {
            ctx = new HealthClinicContext();
        }
        public void Agendar(Consultas consulta)
        {
            ctx.Consultas.Add(consulta);
            ctx.SaveChanges();
        }

        public void Cancelar(Guid id)
        {
            ctx.Consultas.Remove(ctx.Consultas.FirstOrDefault(x => x.IdConsulta == id));
        }

        public void IncluirDescricao(string descricao, Guid Id)
        {
            ctx.Consultas.FirstOrDefault(x => x.IdConsulta == Id).Descricao = descricao;
            ctx.SaveChanges();
        }

        public List<Consultas> ListarPorUsuario(Guid idUsuario)
        {
            List<Consultas> MinhasConsultas = new List<Consultas>();
            MinhasConsultas = ctx.Consultas.Where(x => x.Medico.IdUsuario == idUsuario).ToList();
            if (MinhasConsultas == null)
            {
                MinhasConsultas = ctx.Consultas.Where(x => x.Paciente.idUsuario == idUsuario).ToList();
                return MinhasConsultas;
            }
            else
            {
                return MinhasConsultas;
            }
        }
    }
}
