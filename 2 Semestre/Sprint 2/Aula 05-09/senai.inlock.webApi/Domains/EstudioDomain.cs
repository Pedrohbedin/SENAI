namespace senai.inlock.webApi_.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }
        public string? Nome { get; set; }
        public List<JogoDomain> Jogos { get; set; }
    }
}
