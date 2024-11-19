using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    public class Dashboard : Controller
    {
        [Area("Admin")]//Çalıştığımız areayı bildirmemiz gerekir.
        public IActionResult Index()
        {
            return View();
        }
    }
}