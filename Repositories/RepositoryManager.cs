using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        private readonly RepositoryContext _context;

        public RepositoryManager(IProductRepository productRepository, RepositoryContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}