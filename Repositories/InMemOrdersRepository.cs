using Catalog.Entities;
using Orders.Entities;

namespace Orders.Repositories
{
    public class InMemOrdersRepository
    {
        private readonly List<Product> products =
        [
            new Product { Id = Guid.Parse("9d70b801-e27d-4650-b633-60f7930e2fb8"), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 49, CreatedDate = DateTimeOffset.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 44, CreatedDate = DateTimeOffset.UtcNow }
        ];


        private readonly List<Order> orders;

        public InMemOrdersRepository()
        {
            orders =
            [
                new() { Id = Guid.Parse("9d70b801-e27d-4650-b633-60f7930e2fb8"), Products = products, TotalPrice = products.Sum(product => product.Price), CreatedDate = DateTimeOffset.UtcNow },
                new() { Id = Guid.NewGuid(), Products = products, TotalPrice = 12.4, CreatedDate = DateTimeOffset.UtcNow },
                new() { Id = Guid.NewGuid(), Products = products, TotalPrice = 12.4, CreatedDate = DateTimeOffset.UtcNow }
            ];
        }

        public Order GetOrder(Guid id)
        {
            var orderAlreadyExsits = orders.Find(item => item.Id == id);

            if(orderAlreadyExsits == null)
            {
                throw new KeyNotFoundException($"Order with id: ${id} was not found");
            }

            return orderAlreadyExsits;
        }
    }
}