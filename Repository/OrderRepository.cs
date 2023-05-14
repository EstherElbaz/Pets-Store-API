using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        storeWebsiteContext _storeWebsiteContext;
        public OrderRepository(storeWebsiteContext storeWebsiteContext)
        {
            _storeWebsiteContext = storeWebsiteContext;
        }
        public async Task<Order> addOrder(Order order)
        {
            await _storeWebsiteContext.Orders.AddAsync(order);
            await _storeWebsiteContext.SaveChangesAsync();
            return order;
        }

        public async Task<int> getItemPrice(int id)

        {
            var price = _storeWebsiteContext.Products.Where(p => p.ProductId == id).Select(p => p.ProductPrice).FirstOrDefault();
            return price;

        }


    }
}
