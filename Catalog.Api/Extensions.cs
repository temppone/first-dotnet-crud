using Catalog.Api.ModelView;
using Catalog.Api.Entities;

namespace Catalog.Api
{
    public static class Extensions{
        public static ProductResponseViewModel AsModelView(this Product product){
            return new ProductResponseViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CreatedDate = product.CreatedDate,
            };
        }
    }
}