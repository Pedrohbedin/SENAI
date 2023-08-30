using System.Data;
using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE04-S14; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Login(string Email, string Senha)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                UsuarioDomain Usuario;
                string queryLogin = $"SELECT * FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("Senha", Senha);

                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.Read())
                        {
                            Usuario = new UsuarioDomain()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Email = rdr["Email"].ToString(),
                                Senha = rdr["Senha"].ToString(),
                                Permicao = Convert.ToBoolean(rdr["Permicao"])
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
