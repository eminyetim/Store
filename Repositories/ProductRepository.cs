using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
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
            return p1.CategoryId is null 
                ? _context
                    .Products
                    .Include(p => p.Category)
                : _context
                    .Products
                    .Include(p=>p.Category)
                    .Where(p=>p.CategoryId.Equals(p1.CategoryId));
        }
    }
}