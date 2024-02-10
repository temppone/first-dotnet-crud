using Catalog.Api.ModelView;
using Catalog.Api.Entities;
using Microsoft.AspNetCore.Http.Features;

namespace Catalog.Api.Repositories
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