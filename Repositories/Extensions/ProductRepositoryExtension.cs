using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension 
    {
        public static  IQueryable<Product> FiltrdByCategoryId(this IQueryable<Product> products , int? categoryID ) // This product repository genişletmemde yardımcı oluyor.
        {
            if(categoryID == null)
            {
                return products;
            }
            else 
                return products.Where(prd=> prd.CategoryId == categoryID);
        }
        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products , string? searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm)) // searchTerm null ya da boşluk ise
                return products;
            else
               return products.Where(prd => prd.ProductName.ToLower().Contains(searchTerm.ToLower())); //Contains içeriyormu diye kontrol yapar.
        }
        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products , int? minPrice , int? maxPrice , bool isValidPrice)
        {
            if(isValidPrice)
                return products.Where(prd=> prd.Price >= minPrice && prd.Price <= maxPrice);
            else 
                return products;
        }
        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products,int pageNumber, int pageSize)
        {
            return products
                .Skip(((pageNumber-1)*pageSize))
                .Take(pageSize);
        }
    }
}