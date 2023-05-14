using Entites;
namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order order);
        Task<int> getItemPrice(int id);
    }
}