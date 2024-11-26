using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetShowCaseProducts(bool trackChanges); 
        IQueryable<Product> GetAllProductWithDetails(ProductRequestParameters p);

        public Product? GetOneProduct(int id , bool trackChanges);
        void CreateOneProduct(Product product); 
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product product);
        
    }   
}