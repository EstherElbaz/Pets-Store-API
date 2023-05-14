using Entites;
using Repository;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> addOrder(Order order);
    }
}