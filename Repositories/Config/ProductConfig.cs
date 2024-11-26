using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(  
                new Product() { ProductId = 1, CategoryId=2 , ImageUrl="/images/1.png", ProductName = "Computer", Price = 17_000 , ShowCase=false },
                new Product() { ProductId = 2, CategoryId=2 , ImageUrl="/images/2.png", ProductName = "Keyboard", Price = 2_000 , ShowCase=false },
                new Product() { ProductId = 3, CategoryId=2 , ImageUrl="/images/3.png", ProductName = "Mouse", Price = 500 , ShowCase=false },
                new Product() { ProductId = 4, CategoryId=2 , ImageUrl="/images/4.png", ProductName = "Monitor", Price = 1_200 , ShowCase=false },
                new Product() { ProductId = 5, CategoryId=2 , ImageUrl="/images/5.png", ProductName = "Deck", Price = 1_200 , ShowCase=false },
                new Product() { ProductId = 6, CategoryId=1 , ImageUrl="/images/6.png", ProductName = "History", Price = 1_200 , ShowCase=false },
                new Product() { ProductId = 7, CategoryId=1 , ImageUrl="/images/7.png", ProductName = "Hamlet", Price = 1_200 , ShowCase=false },
                new Product() { ProductId = 8, CategoryId=1 , ImageUrl="/images/7.png", ProductName = "Xp-Pen", Price = 1_400 , ShowCase=true },
                new Product() { ProductId = 9, CategoryId=2 , ImageUrl="/images/5.png", ProductName = "Galaxy FE", Price = 1_500 , ShowCase=true },
                new Product() { ProductId = 10, CategoryId=1 , ImageUrl="/images/1.png", ProductName = "Hp Mouse", Price = 200 , ShowCase=true }
            );
        }     
    }
}