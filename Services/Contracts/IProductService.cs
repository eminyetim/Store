using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetShowCaseProducts(bool trackChanges);
        IQueryable<Product> GetAllProductWithDetails(ProductRequestParameters p);
        Product? GetOneProduct(int id , bool trackChanges);
        void CreateProduct(ProductDtoForInsertion product);

        void UpdateOneProduct(ProductDtoForUpdate product);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}