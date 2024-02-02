using System.Security.Cryptography.X509Certificates;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController(IProductsRepository repository) : ControllerBase
    { 
        private readonly IProductsRepository repository = repository;

        [HttpGet]
        public IEnumerable<ProductResponseViewModel> GetProducts()
        {
            var items = repository.GetProducts().Select(product => product.AsDto());

            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponseViewModel> GetProduct(Guid id)
        {
            var product = repository.GetProduct(id);

            return product.AsDto();
        }

        [HttpPost]
        public ActionResult<ProductResponseViewModel> CreateProduct(CreateProductViewModel productDto)
        {

            Product product = new(){
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Price = productDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id}, product.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult<ProductResponseViewModel> UpdateProduct(Guid id, UpdateProductViewModel productDto)
        {
            var existingProduct = repository.GetProduct(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            Product updatedProduct = existingProduct with
            {
                Name = productDto.Name,
                Price = productDto.Price,
            };

            repository.UpdateProduct(updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var existingProduct = repository.GetProduct(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            repository.DeleteProduct(id);

            return NoContent();
        }
    }
}