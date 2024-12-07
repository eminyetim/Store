using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    public class Dashboard : Controller
    {
        private readonly IServiceManager _manager;

        public Dashboard(IServiceManager manager)
        {
            _manager = manager;
        }

        [Area("Admin")]//Çalıştığımız areayı bildirmemiz gerekir.
        //[Authorize(Roles ="Admin")]
        public IActionResult Index()
        {  
            return View();
        }

    }
}