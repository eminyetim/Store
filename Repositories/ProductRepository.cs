using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository // Sealed class bu klasın bir daha miras alınamıyacak hale getirir.
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }
        public void CreateOneProduct(Product product) => Create(product);
        public void DeleteOneProduct(Product product) => Remove(product);
        public void UpdateOneProduct(Product product) => Update(product);
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
        public IQueryable<Product> UpdateOneProduct(bool trackChanges) => FindAll(trackChanges);
        public Product? GetOneProduct(int id , bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id),trackChanges);
        }
        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
            .Where( p => p.ShowCase==true);
        }
        public IQueryable<Product> GetAllProductWithDetails(ProductRequestParameters p1)
        {
            return 
                _context.Products
                .FiltrdByCategoryId(p1.CategoryId)
                .FilteredBySearchTerm(p1.searchTerm)
                .FilteredByPrice(p1.MinPrice,p1.MaxPrice,p1.IsValidPrice)
                .ToPaginate(p1.pageNumber , p1.pageSize); // Sayfalamaya göre arama yap.
        }
    }
}