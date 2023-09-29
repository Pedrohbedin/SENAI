namespace webapi.HealthClinic.CodeFirst.tarde.Utils
{
    /// <summary>
    /// Classe responsável por fornecer métodos para criptografia de senhas.
    /// </summary>
    public class Criptografia
    {
        /// <summary>
        /// Gera um hash seguro a partir de uma senha.
        /// </summary>
        /// <param name="senha">A senha a ser criptografada.</param>
        /// <returns>O hash gerado.</returns>
        public static string GerarHash(string senha)
        {
            // Utiliza a biblioteca BCrypt.NET para gerar um hash seguro da senha.
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Compara uma senha fornecida com um hash de senha armazenado no banco de dados.
        /// </summary>
        /// <param name="senhaForm">A senha fornecida pelo usuário.</param>
        /// <param name="senhaBanco">O hash de senha armazenado no banco de dados.</param>
        /// <returns>True se as senhas coincidirem, caso contrário, false.</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            // Utiliza a biblioteca BCrypt.NET para comparar a senha fornecida com o hash do banco de dados.
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
