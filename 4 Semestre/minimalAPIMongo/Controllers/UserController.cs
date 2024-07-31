using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabaseBase.GetCollection<User>("user");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Listar()
        {
            try
            {
                var product = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(User user)
        {
            try
            {
                await _user.InsertOneAsync(user);

                return Ok("Usuario cadastrado com sucesso");
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
                var user = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();
                return Ok(user.Where(x => x.Id == id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarPorId(User user)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id);
                if (filter != null)
                {
                    await _user.ReplaceOneAsync(filter, user);

                    return Ok("Usuario atualizado com sucesso");
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
                await _user.DeleteOneAsync(x => x.Id == id);

                return Ok("Usuario deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
