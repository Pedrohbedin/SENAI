using Moq;
using NuGet.Frameworks;
using ProductsAPI.Domains;
using ProductsAPI.Interfaces;
using ProductsAPI.Repository;

namespace apiTestxUnit
{
    public class ProductsTest
    {
        /// <summary>
        /// Teste para a funcionalidade de listar todos os produtos 
        /// </summary>
        [Fact]
        public void Get()
        {
            //Arrange
            
            //Lista de produtos 
            var productList = new List<Products>
            {
                new Products{ IdProduct = Guid.NewGuid(), Nome = "Produto 1", Price = 78},
                new Products{ IdProduct = Guid.NewGuid(), Nome = "Produto 2", Price = 90},
                new Products{ IdProduct = Guid.NewGuid(), Nome = "Produto 3", Price = 345}
            };

            //Cria um objeto de simulação do tipo ProductRepository
            var mockRepository = new Mock<IProductsRepository>();

            //Configura o método "Listar" para que quando for acionado retorne a lista "mockada"
            mockRepository.Setup(x => x.Listar()).Returns(productList);

            //Act

            //Executando o método "Listar" e atribue a resposta em result 
            var result = mockRepository.Object.Listar();

            //Assert

            Assert.Equal(3, result.Count());
        }
        [Fact]
        public void Post()
        {

            var products = new Products { IdProduct = Guid.NewGuid(), Nome = "Produto 1", Price= 2};

            var productList = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Cadastrar(products)).Callback<Products>(x => productList.Add(products));

            mockRepository.Object.Cadastrar(products);

            Assert.Contains(products, productList);
        }
        [Fact]
        public void Delete()
        {

            var products = new Products { IdProduct = Guid.NewGuid(), Nome = "Produto 1", Price = 2 };

            var productList = new List<Products>
            {
                products
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Deletar(products.IdProduct)).Callback<Guid>(x => productList.Remove(products));

            mockRepository.Object.Deletar(products.IdProduct);

            Assert.DoesNotContain(products, productList);
        }
        [Fact]
        public void GetById()
        {
            var products = new Products 
            { 
                IdProduct = Guid.NewGuid(), 
                Nome = "Produto 1",
                Price = 2
            };

            var productList = new List<Products>
            {
                products
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.BuscarPorId(products.IdProduct)).Returns(productList.FirstOrDefault(x => x.IdProduct == products.IdProduct)!);
            var result = mockRepository.Object.BuscarPorId(products.IdProduct);

            Assert.Equal(products, result);

        }
        [Fact]
        public void Atualizar()
        {
            var productList = new List<Products>
            {
               new Products{IdProduct = Guid.NewGuid(),
               Nome = "Produto Teste",
               Price = 30}
            };

            var products = new Products
            {
                IdProduct = productList[0].IdProduct,
                Nome = "Produto 1",
                Price = 2
            };

            var produtoAtualizar = productList.FirstOrDefault(y => y.IdProduct == products.IdProduct);

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.Atualizar(products, products.IdProduct))
    .Callback<Products, Guid>((products, IdProduct) =>
    {
        var productToUpdate = productList.FirstOrDefault(p => p.IdProduct == IdProduct);
  
        productToUpdate.Nome = products.Nome;
        productToUpdate.Price = products.Price;
        
    });

            mockRepository.Object.Atualizar(products, productList[0].IdProduct);

            Assert.Equal(productList[0], products);
        }
    }
}