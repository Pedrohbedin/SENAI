using AdicionarProduto;

namespace AdicionarProdutoTest
{
    public class UnitTest1
    {
        [Fact]
        public void AdicionarProdutoTeste()
        {
            Produto produto1 = new Produto();
            produto1.Nome = "Produto2";
            produto1.Quantidade = 1;

            //Assert.Equal(GerenciadorDeProdutos.AdicionarProduto(produto1), "A quantidade do produto foi incrementada");
            Assert.Equal(GerenciadorDeProdutos.AdicionarProduto(produto1), "Produto cadastrado com sucesso");
        }
    }
}