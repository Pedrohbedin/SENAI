using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE04-S14; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                string queryInsert = "INSERT INTO Jogo(IdEstudio,Nome,Descricao, DataLancamento,Valor) VALUES (@IdEstudio,@Nome,@Descricao,@DataLancamento, @Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelector = "SELECT IdJogo, Jogo.IdEstudio, Jogo.Nome AS JogoNome, Descricao, DataLancamento, Valor, Estudio.IdEstudio, Estudio.Nome AS EstudioNome FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelector, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["JogoNome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(rdr["Valor"]),
                            Estudio = rdr["EstudioNome"].ToString()
                        };
                        ListaJogos.Add(jogo);
                    }
                }
            }
            return ListaJogos; 
        }
    }
}
