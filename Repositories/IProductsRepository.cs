using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Http.Features;

namespace Catalog.Repositories
{
    public interface IProductsRepository
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProducts();
        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Guid id);
    }
}