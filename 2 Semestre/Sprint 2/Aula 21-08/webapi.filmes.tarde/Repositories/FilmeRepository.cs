using System.Data;
using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE04-S14; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        // Método para atualizar informações de um filme com base no corpo da requisição
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                // Consulta SQL para atualizar informações de um filme
                string queryUpdate = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Parâmetros para a consulta SQL
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.Genero.IdGenero);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.ExecuteNonQuery(); // Executa a consulta de atualização
                }
            }
        }

        // Método para atualizar informações de um filme com base na URL
        public void AtualizarIdURL(int id, FilmeDomain filme)
        {
            SqlDataReader rdr;

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                // Consulta SQL para atualizar informações de um filme
                string queryUpdate = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Parâmetros para a consulta SQL
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.Genero.IdGenero);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.ExecuteNonQuery(); // Executa a consulta de atualização
                }
            }
        }

        // Método para buscar informações de um filme por ID
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                // Consulta SQL para buscar informações de um filme e seu gênero associado
                string querySearched = @"
                SELECT *
                FROM Filme
                INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero
                WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(querySearched, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.Read())
                        {
                            // Cria um objeto FilmeDomain com base nos dados da consulta
                            GeneroDomain genero = new GeneroDomain()
                            {
                                IdGenero = rdr.IsDBNull(rdr.GetOrdinal("IdGenero")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IdGenero")),
                                Nome = rdr.IsDBNull(rdr.GetOrdinal("Nome")) ? string.Empty : rdr.GetString(rdr.GetOrdinal("Nome"))
                            };

                            FilmeDomain Filme = new FilmeDomain()
                            {
                                IdFilme = rdr.IsDBNull(rdr.GetOrdinal("IdFilme")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IdFilme")),
                                Titulo = rdr.IsDBNull(rdr.GetOrdinal("Titulo")) ? string.Empty : rdr.GetString(rdr.GetOrdinal("Titulo")),
                                IdGenero = rdr.IsDBNull(rdr.GetOrdinal("IdGenero")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("IdGenero")),
                                Genero = genero
                            };

                            return Filme; // Retorna o objeto FilmeDomain encontrado
                        }
                    }
                }
            }

            return null; // Retorna null se o filme não for encontrado
        }

        // Método para cadastrar um novo filme
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                // Consulta SQL para inserir um novo filme na base de dados
                string queryInsert = "INSERT INTO Filme (IdGenero, Titulo) VALUES (@IdGenero, @Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Parâmetros para a consulta SQL
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.Genero.IdGenero);
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.ExecuteNonQuery(); // Executa a consulta de inserção
                }
            }
        }

        // Método para deletar um filme por ID
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = $"DELETE FROM Filme WHERE Filme.IdFilme = {id}";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery(); // Executa a consulta de exclusão
                }
            }
        }

        // Método para listar todos os filmes
        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        // Cria objetos FilmeDomain e GeneroDomain com base nos dados da consulta
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        FilmeDomain Filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Genero = genero
                        };
                        ListaFilmes.Add(Filme); // Adiciona o objeto FilmeDomain à lista
                    }
                }
            }
            return ListaFilmes; // Retorna a lista de filmes
        }
    }
}