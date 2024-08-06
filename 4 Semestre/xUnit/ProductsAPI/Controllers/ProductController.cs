using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Domains;
using ProductsAPI.Interfaces;
using ProductsAPI.Repository;
using ProductsAPI.ViewModel;

namespace ProductsAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        public ProductController()
        {
            _productsRepository = new ProductsRepository();
        }
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(ProductViewModel _product)
        {
            Products product = new Products{
                Nome = _product.Nome,
                Price = _product.Price,
            };
            _productsRepository.Cadastrar(product);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id) 
        {
            _productsRepository.Deletar(id);
            return Ok();
        }
        [HttpGet("Listar")]
        public IActionResult Listar() 
        {
            return Ok(_productsRepository.Listar());
        }
        [HttpGet("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id) 
        {
            return Ok(_productsRepository.BuscarPorId(id));
        }
        [HttpPut("Atualizar")]
        public IActionResult Atualizar(Products product, Guid id)
        {
            _productsRepository.Atualizar(product, id);
            return Ok();
        }
    }
}
