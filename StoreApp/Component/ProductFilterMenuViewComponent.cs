using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Component
{
    public class ProductFilterMenuViewComponent:ViewComponent 
    {
        public IViewComponentResult Invoke()// Bu bizim componenti çağırmamız göstermemizi sağlıyor.
        {
            return View();
        }
    }
}