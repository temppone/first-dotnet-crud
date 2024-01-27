using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IProductsRepository
    {
        Product GetItem(Guid id);
        IEnumerable<Product> GetProducts();
        void CreateProduct(Product product);
        void UpdateItem(Product product);
        void DeleteProduct(Guid id);
    }
}