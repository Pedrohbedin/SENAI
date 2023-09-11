using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace senai.inlock.webApi_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE04-S14; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public TiposUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                // Consulta SQL para buscar informações de um filme e seu gênero associado
                string querySearched = @"
                SELECT *
                FROM TiposUsuario
                WHERE IdTipoUsuario = @IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(querySearched, con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", id);

                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.Read())
                        {
                            // Cria um objeto FilmeDomain com base nos dados da consulta
                            TiposUsuarioDomain tipoUsuario = new TiposUsuarioDomain()
                            {
                                IdTipoUsuario = rdr.IsDBNull(rdr.GetOrdinal("IdTipoUsuario")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IdTipoUsuario")),
                                Titulo = rdr.IsDBNull(rdr.GetOrdinal("Titulo")) ? string.Empty : rdr.GetString(rdr.GetOrdinal("Titulo"))
                            };
                            return tipoUsuario; // Retorna o objeto FilmeDomain encontrado
                        }
                    }
                }
            }

            return null; // Retorna null se o filme não for encontrado
        }
    }
}
