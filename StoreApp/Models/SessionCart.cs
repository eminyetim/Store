using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore] //Serileştirme Json formatına dönüştürme.
        public ISession? Session { get; set; }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        public override void AddItem(Product product, int quantity) //eziyoruz.
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart",this); // this, serilaize işlemi yapıyor.
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart",this); // Class(base) kendi işini yapıyor ben burda sessiona kayıt ediyorum.
        }
    }
}