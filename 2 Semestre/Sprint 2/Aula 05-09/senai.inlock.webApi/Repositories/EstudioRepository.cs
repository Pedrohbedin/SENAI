using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE04-S14; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> ListaDeEstudiosEJogos = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelector = "SELECT IdEstudio, Nome AS EstudioNome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelector, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["EstudioNome"].ToString(),
                            Jogos = new List<JogoDomain>()
                        };
                        using (SqlConnection con2 = new SqlConnection(StringConexao))
                        {
                            string querySelectAllGames = "SELECT IdJogo, Jogo.IdEstudio, Jogo.Nome AS JogoNome, Descricao, DataLancamento, Valor, Estudio.IdEstudio, Estudio.Nome AS EstudioNome FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio Where Jogo.IdEstudio = @IdEstudio";

                            con2.Open();

                            SqlDataReader rdr2;

                            using (SqlCommand cmd2 = new SqlCommand(querySelectAllGames, con2))
                            {
                                cmd2.Parameters.AddWithValue("@IdEstudio", rdr["IdEstudio"]);

                                rdr2 = cmd2.ExecuteReader();

                                while (rdr2.Read())
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        IdJogo = Convert.ToInt32(rdr2["IdJogo"]),
                                        IdEstudio = Convert.ToInt32(rdr2["IdEstudio"]),
                                        Nome = rdr2["JogoNome"].ToString(),
                                        Descricao = rdr2["Descricao"].ToString(),
                                        DataLancamento = Convert.ToDateTime(rdr2["DataLancamento"]),
                                        Valor = Convert.ToDecimal(rdr2["Valor"]),
                                        Estudio = rdr2["EstudioNome"].ToString()
                                    };

                                    estudio.Jogos.Add(jogo);
                                }
                            }
                        }
                        ListaDeEstudiosEJogos.Add(estudio);
                    }

                }
            }
            return ListaDeEstudiosEJogos;
        }

    }
}

