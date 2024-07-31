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
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<Client> _client;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabaseBase.GetCollection<Order>("order");
            _product = mongoDbService.GetDatabaseBase.GetCollection<Product>("product");
            _client = mongoDbService.GetDatabaseBase.GetCollection<Client>("client");
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Listar()
        {
            try
            {
                var order = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                List<Product> products = [];

                foreach (var item in order)
                {
                    var filter = Builders<Product>.Filter.In(x => x.Id, item.ProductId);

                    item.Products = await _product.Find(filter).ToListAsync();
                }

                return Ok(order);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Cadastrar(OrderViewModel orderViewModel)
        {
            List<Product> products = [];

            foreach (var item in orderViewModel.ProductId!) 
            {
                products.Add(_product.Find(x => x.Id == item).FirstOrDefault());
            }

            var client = _client.Find(x => x.Id == orderViewModel.ClientId).FirstOrDefault();

            if (client == null)
            {
                return NotFound("Cliente não cadastrado");
            }

            try
            {
                Order order = new Order
                {
                    Date = orderViewModel.Date,
                    Status = orderViewModel.Status,
                    ProductId = orderViewModel.ProductId,
                    ClientId = orderViewModel.ClientId,
                    Client = client,
                    Products = products,
                };

                await _order.InsertOneAsync(order);

                return Ok("Pedido cadastrada com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
