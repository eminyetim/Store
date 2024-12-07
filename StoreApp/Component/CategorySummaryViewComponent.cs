using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Component
{
    public class CategorySummary : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategorySummary(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                .CategoryService
                .GetAllCategories(false)
                .Count().
                ToString();
        }
    }
}