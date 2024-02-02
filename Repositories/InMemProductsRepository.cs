using Catalog.Entities;

namespace Catalog.Repositories
{


    public class InMemProductsRepository : IProductsRepository
    {
        private readonly List<Product> products = new()
        {
            new Product { Id = Guid.Parse("9d70b801-e27d-4650-b633-60f7930e2fb8"), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 49, CreatedDate = DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 44, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProduct(Guid id)
        {                
            var productAlreadyExists = products.Find(product => product.Id == id);

            if(productAlreadyExists == null)
            {
                throw new KeyNotFoundException($"Item with id: {id} was not found");
            }

            return productAlreadyExists;
        }

        public void CreateProduct(Product product)
        {
            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var index = products.FindIndex(existingProduct => existingProduct.Id == product.Id);

            products[index] = product;
        }

        public void DeleteProduct(Guid id)
        {
            var index = products.FindIndex(product => product.Id == id);

            products.RemoveAt(index);
        }
    }
}