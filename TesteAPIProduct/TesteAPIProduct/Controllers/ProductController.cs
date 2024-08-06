using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteAPIProduct.Domains;
using TesteAPIProduct.Interface;
using TesteAPIProduct.Migrations;

namespace TesteAPIProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productsRepository;

        public ProductController(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_productsRepository.GetProducts());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Products product)
        {
            try
            {
                _productsRepository.Post(product);
                return Ok(product);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
