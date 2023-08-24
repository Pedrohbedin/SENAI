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
            throw new NotImplementedException();
        }

        public void AtualizarIdURL(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
                string queryInsert = "INSERT INTO Genero VALUES ('" + novoGenero.Nome + "')";

                //Declara o sql command passando a query que será receptada e a conexão com o banco de dados 
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
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

                string queryDelete = $"DELETE FROM Genero WHERE IdGenero = 17";

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
