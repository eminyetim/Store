using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]

    public class OrderController : Controller
    {
        private readonly IServiceManager _manager; //DIP

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var orders = _manager.OrderService.Orders;
            return View(orders);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.Complate(id);
            return RedirectToAction("Index");
        }
    }
}