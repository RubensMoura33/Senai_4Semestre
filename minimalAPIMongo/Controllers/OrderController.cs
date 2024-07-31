using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using minimalAPIMongo.ViewModels;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order>? _order;
        private readonly IMongoCollection<Client>? _client;
        private readonly IMongoCollection<Product>? _product;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();
                order.Id = orderViewModel.Id;
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound("Usuario nao existe");
                }
                order.Client = client;

                await _order.InsertOneAsync(order);

                return StatusCode(201, order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                //lista todos os pedidos da collection "Order"
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                //Percorre todos os itens da lista
                foreach (var order in orders)
                {
                    //verifica se existe uma lista de produtos para cada peddido
                    if (order.ProductId != null)
                    {
                        //Dentro da collection "Product" faz um filtro ("separa" os produtos que estao dentro do pedido

                        //seleciona os ids dos produtos dentri da collection cujo o id esta presente na lista "order.ProductId"
                        var filter = Builders<Product>.Filter.In(p => p.Id, order.ProductId);

                        //busca os produtos correspondentes ao pedido e adiciona em "order.Products"
                        //traz as informacoes dos produtos
                        order.Product = await _product.Find(filter).ToListAsync();
                    }
                }

                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
                await _order.DeleteOneAsync(filter);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                if (order != null)
                {
                    var products = await _product.Find(x => order.ProductId.Contains(x.Id)).ToListAsync();
                    order.Product = products;
                }
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();
                order.Id = orderViewModel.Id;
                order.Date = orderViewModel.Date;
                order.Status = orderViewModel.Status;
                order.ProductId = orderViewModel.ProductId;
                order.ClientId = orderViewModel.ClientId;


                var filtro = Builders<Product>.Filter.In(p => p.Id, order.ProductId);


                order.Product = await _product.Find(filtro).ToListAsync();

                var filter = Builders<Order>.Filter.Eq(x => x.Id, order.ClientId);
                await _order.ReplaceOneAsync(filter, order);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}
