namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        public EstudioDomain? Estudio { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataLancamento { get; set; }

        public decimal? Valor { get; set; }
    }
}
