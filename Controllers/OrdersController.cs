using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Orders.Entities;
using Orders.Repositories;

namespace Orders.Controllers
{
    [ApiController]
    [Route("orders")]

    public class OrdersController(IOrdersRepository repository) : ControllerBase
    {
        private readonly IOrdersRepository repository = repository;

        [HttpGet("{id}")]
        public Order GetItem(Guid id)
        {
            var order = repository.GetOrder(id);
            
            return order;
        }

        public List<Order> GetOrders()
        {
            var orders = repository.GetOrders();

            return orders;
        }
    }
}