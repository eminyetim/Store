using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Pages
{
    public class CartModel:PageModel 
    {
        private readonly IServiceManager _manager;
        public Cart Cart {get;set;}
        public string ReturnUrl { get; set; } = "/"; // Bu model hangi sayfadan çağrıldığını belirtir.

        public CartModel(IServiceManager manager , Cart cartService) // Bu cartService Program.cs Carttan gelen cart.
        {
            _manager = manager;
            Cart = cartService;
        }    

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager
                .ProductService
                .GetOneProduct(productId,false);

            if(product is not null)
            {
                // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product,1);
                // HttpContext.Session.SetJson<Cart>("cart",Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl}); // returnUrl
        }
        public IActionResult OnPostRemove(int id ,  string retunUrl)
        {
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();        
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId == id).Product);// Cart içinden ilk dönen Producttı siliyorum Ama Product id si ile bulunuyor.
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();        
            return Page();
        }
    }    
}