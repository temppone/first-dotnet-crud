using Catalog.Entities;
using Orders.Entities;

namespace Catalog.Repositories
{
    public interface IOrdersRepository
    {
        Order GetOrder(Guid id);
        List<Order> GetOrders();
    }
}