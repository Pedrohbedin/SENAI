using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        private string StringConexao = "Data Source = NOTE04-S14; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            SqlDataReader rdr;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryUpdate = $"UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public void AtualizarIdURL(int id, GeneroDomain genero)
        {

            
            SqlDataReader rdr;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryURLUpdate = $"UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryURLUpdate, con))
                {
                    cmd.Parameters.AddWithValue("Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("IdGenero", genero.IdGenero);
                    con.Open(); 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            int IdGenero = new int();
            SqlDataReader rdr;
            GeneroDomain generoEncontradado = new GeneroDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                con.Open();

                string querySearched = $"SELECT IdGenero, Nome FROM Genero WHERE Genero.IdGenero LIKE @IdGenero";

                using (SqlCommand cmd = new SqlCommand(querySearched, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString()
                        };
                        generoEncontradado = generoBuscado;
                    }
                }
            }
            return generoEncontradado;
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>

        public void Cadastrar(GeneroDomain novoGenero)  
        {
            //Declara a SqlConnect passando a string de conexão como parâmetro. 
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Genero VALUES (@Nome)";

                //Declara o sql command passando a query que será receptada e a conexão com o banco de dados 
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
      
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryDelete = $"DELETE FROM Genero WHERE IdGenero = {id}";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>A
        /// Listar todos os objetos do tipo genero
        /// </summary>
        /// <returns>Lista d eobjetos do tipo genero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista onde serão armazenados os gêneros
            List<GeneroDomain> ListaGenero = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };
                        ListaGenero.Add(genero);
                    }
                }
            }
            return ListaGenero;
        }

    }
}
