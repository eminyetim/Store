using System.Security.Cryptography;

namespace Entities.Models
{
    public class Cart{
        
        public List<CartLine> Lines {get;set;}

        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual  void AddItem(Product product , int quantity) // Virtual geçersiz kılar override eder ezilir.
        {
            CartLine? line = Lines.Where(l => l.Product.ProductId == product.ProductId).FirstOrDefault(); // FirstOrDefault yok ya da var.
            if(line is null) // Listede yoksa yenisini ekle
            {
                Lines.Add(new CartLine()
                {   
                    Product = product,
                    Quantity = quantity
                });
            }
            else // var ise miktari arttır.
            {
                line.Quantity += quantity;
            }
        }
   
        public virtual void RemoveLine(Product product) => Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() => Lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
}