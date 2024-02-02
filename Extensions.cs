using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions{
        public static ProductResponseViewModel AsDto(this Product product){
            return new ProductResponseViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CreatedDate = product.CreatedDate,
            };
        }
    }
}