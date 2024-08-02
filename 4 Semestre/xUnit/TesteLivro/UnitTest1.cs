using GerenciamentoDeLivros;

namespace TesteLivro
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string nome = "Nome do livro";
            string descricao = "Descricao do livro";
            Assert.True(Livros.AdicionarLivro(nome, descricao));
        }
    }
}