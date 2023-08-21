using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// É uma interface responsável pelo repositório GeneroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //Function sintaxe - TipoDeRetorno NomeMetodo (TipoParametro NomeParametro)

        /// <summary>
        /// Responsável por cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero"> objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);
        /// <summary>
        /// Retorna todos os gêneros cadastrados
        /// </summary>
        /// <returns></returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto através de seu Id
        /// </summary>
        /// <param name="id">Id do objeto quue será buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);
        /// <summary>
        /// Atualiza um gênero ja existente passando um Id pelo corpo da recsição 
        /// </summary>
        /// <param name="genero">objeto com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);
        /// <summary>
        /// Atualizar um gênero existente passando o Id pelo URL da requisição
        /// </summary>
        /// <param name="id">IdDoObjeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informe</param>
        void AtualizarIdURL(int id, GeneroDomain genero);

        void Deletar(int id);
    }
}
