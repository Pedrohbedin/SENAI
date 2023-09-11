using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE04-S14; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                UsuarioDomain Usuario;
                TiposUsuarioDomain tiposUsuario;
                string queryLogin = $"SELECT IdUsuario, Usuario.IdTipoUsuario AS UIdTipoUsuario, Email, TiposUsuario.Titulo AS Titulo FROM Usuario INNER JOIN TiposUsuario On Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("Senha", Senha);

                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.Read())
                        {
                            tiposUsuario = new TiposUsuarioDomain()
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["UIdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString(),
                            };

                            Usuario = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Email = rdr["Email"].ToString(),
                                IdTipoUsuario = Convert.ToInt32(rdr["UIdTipoUsuario"]),
                                TipoUsuario = tiposUsuario
                            };
                            return Usuario;
                        }
                    }
                }
            }
            return null;
        }
    }
}
