using Microsoft.AspNetCore.Mvc;
using Orders.Entities;
using Orders.Repositories;

namespace Orders.Controllers
{
    [ApiController]
    [Route("orders")]

    public class OrdersController : ControllerBase
    {
        private readonly InMemOrdersRepository ordersRepository;

        public OrdersController()
        {
            ordersRepository = new InMemOrdersRepository();
        }

        [HttpGet("{id}")]
        public Order GetItem(Guid id)
        {
            var item = ordersRepository.GetOrder(id);
            
            return item;
        }
    }
}