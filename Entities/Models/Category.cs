namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; } = string.Empty;

        //Collection navigation property
        public ICollection<Product>? Products {get;set;} //Tanımlamak zorunda değiliz.  
    }
}