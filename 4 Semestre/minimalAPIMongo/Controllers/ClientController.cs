using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using minimalAPIMongo.ViewModel;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<User> _user;

        public ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabaseBase.GetCollection<Client>("client");
            _user = mongoDbService.GetDatabaseBase.GetCollection<User>("user");
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClientViewModel clientViewModel)
        {
            try
            {
                User user = new User
                {
                    Name = clientViewModel.name,
                    Email = clientViewModel.email,
                    Password = clientViewModel.password,
                };
                await _user.InsertOneAsync(user);

                Client client = new Client
                {
                    Cpf = clientViewModel.cpf,
                    Phone = clientViewModel.phone,
                    Address = clientViewModel.address,
                    UserId = user.Id,
                    User = user,
                };
                await _client.InsertOneAsync(client);

                return Ok("Cliente cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Client>>> Listar()
        {
            try
            {
                var clients = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();

                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Deletar(string Id)
        {
            try
            {
                await _client.DeleteOneAsync(x => x.Id == Id);
                return Ok("Cliente deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Id")]
        public async Task<ActionResult<Client>> BuscarPorId(string Id)
        {
            try
            {
                var client = _client.Find(x => x.Id == Id).FirstOrDefault();

                return Ok(client);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
