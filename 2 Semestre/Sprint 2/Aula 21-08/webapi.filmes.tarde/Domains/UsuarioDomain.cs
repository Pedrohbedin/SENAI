namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Permicao { get; set; }
    }
}
