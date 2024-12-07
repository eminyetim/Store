using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Name
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok( _serviceManager.ProductService.GetAllProducts(false) );
        }
    }
}