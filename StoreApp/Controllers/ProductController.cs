using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.controller
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {   
            var model = _manager.ProductService.GetAllProductWithDetails(p);
            return  View(model);        
        } 

        public IActionResult Get([FromRoute(Name ="id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
    }
}