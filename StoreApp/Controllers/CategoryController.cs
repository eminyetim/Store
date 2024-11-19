using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.controller
{
    public class CategoryController : Controller
    {
        private IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategories(false);
            return View(model);
        }
    }
}