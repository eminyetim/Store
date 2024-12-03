using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;  // Readonly sadece 2 yerde değer atanabilir bir tanımlanırken 2 constructer fonksiyonunuda.
        private readonly IMapper _mapper;
        public ProductManager(IRepositoryManager manager , IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }
        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id , false) ?? new Product(); // Eğer null değer dönerse yeni üret.
            _manager.Product.DeleteOneProduct(product);
            _manager.Save();
        }
        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
           return _manager.Product.GetAllProducts(trackChanges);
        }
        public IQueryable<Product> GetAllProductWithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductWithDetails(p);
        }
        public IQueryable<Product> GetLastestProducts(int n, bool trackChanges)
        {
            return _manager
            .Product
            .FindAll(trackChanges)
            .OrderByDescending(prd => prd.ProductId)  // product Id ye göre sırala.
            .Take(n); // n adet.
        }
        public Product? GetOneProduct(int id, bool trackChanges)
        {
           var product =  _manager.Product.GetOneProduct(id , trackChanges);
            if(product is null)
                    throw new Exception("Product not found");
            return product;
        }
        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product  = GetOneProduct(id,trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IEnumerable<Product> GetShowCaseProducts(bool trackChanges)
        {
            var products = _manager.Product.GetShowCaseProducts(trackChanges);
            return products;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            // var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            // entity.ProductName = productDto.ProductName;
            // entity.Price = productDto.Price;
            // entity.CategoryId = productDto.CategoryId;
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
        }
    }
}