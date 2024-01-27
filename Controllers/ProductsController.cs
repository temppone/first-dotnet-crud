using System.Security.Cryptography.X509Certificates;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("products")]
    public class ItemsController(IProductsRepository repository) : ControllerBase
    { 
        private readonly IProductsRepository repository = repository;

        [HttpGet]
        public IEnumerable<Product> GetItems()
        {
            var items = repository.GetProducts();
            return items;
        }

        [HttpGet("{id}")]
        public Product GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            return item;
        }

        [HttpPost]
        public Product CreateItem(Product item)
        {
            repository.CreateProduct(item);
            return item;
        }

        public void UpdateItem(Guid id, Product item)
        {
            var existingItem = repository.GetItem(id);

            var updatedItem = existingItem with 
            {
                Name = item.Name,
                Price = item.Price
            };

            repository.UpdateItem(updatedItem);
        }

    }
}