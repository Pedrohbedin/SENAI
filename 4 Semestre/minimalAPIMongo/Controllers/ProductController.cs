using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabaseBase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Listar()
        {
            try
            {
                var product = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Product product)
        {
            try
            {
                await _product.InsertOneAsync(product);

                return Ok("Produto cadastrado com sucesso");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> BsucarPorId(string id)
        {
            try
            {
                var product = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(product.Where(x => x.Id == id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarPorId(Product produto)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(x => x.Id, produto.Id);
                if (filter != null)
                {
                    await _product.ReplaceOneAsync(filter, produto);

                    return Ok("Atualizado com sucesso");
                }

                return NotFound();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await _product.DeleteOneAsync(x => x.Id == id);

                return Ok("Produto deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
