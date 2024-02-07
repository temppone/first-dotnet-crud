using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Http.Features;

namespace Catalog.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetProductAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
    }
}