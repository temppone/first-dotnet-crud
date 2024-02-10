using System.Security.Cryptography.X509Certificates;
using Catalog.Api.ModelView;
using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController(IProductsRepository repository) : ControllerBase
    { 
        private readonly IProductsRepository repository = repository;

        [HttpGet]
        public async Task<IEnumerable<ProductResponseViewModel>> GetProductsAsync()
        {
            var items = (await repository.GetProductsAsync())
                        .Select(product => product.AsModelView());

            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseViewModel>> GetProductAsync(Guid id)
        {
            var product = await repository.GetProductAsync(id);

            if (product is null){
                return NotFound();
            }

            return product.AsModelView();
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseViewModel>> CreateProductAsync(CreateProductViewModel createProductViewModel)
        {

            Product product = new(){
                Id = Guid.NewGuid(),
                Name = createProductViewModel.Name,
                Price = createProductViewModel.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetProductAsync), new {id = product.Id}, product.AsModelView());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseViewModel>> UpdateProductAsync(
            Guid id,
            UpdateProductViewModel productViewModel
        )
        {
            var existingProduct = await repository.GetProductAsync(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            Product updatedProduct = existingProduct with
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
            };

            await repository.UpdateProductAsync(updatedProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(Guid id)
        {
            var existingProduct = await repository.GetProductAsync(id);

            if(existingProduct is null)
            {
                return NotFound();
            }

            await repository.DeleteProductAsync(id);

            return NoContent();
        }
    }
}