using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();       
        
        [Required(ErrorMessage ="Name is required.")]
        public string? Name { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public  DateTime OrderAt { get; set ; } = DateTime.Now;

    }
}