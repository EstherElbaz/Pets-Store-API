using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entites;
using Microsoft.Extensions.Logging;
namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;
        public OrderService(IOrderRepository IOrderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _OrderRepository = IOrderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }



        public async Task<Order> addOrder(Order order)
        {
            int checkedSum = 0;
            foreach (OrderItem item in order.OrderItems)
            {
                checkedSum += Convert.ToInt32(_OrderRepository.getItemPrice(item.ProductId));
            }
            if (checkedSum != order.OrderSum)
            {
                _logger.LogError(order.UserId + "is a thief!");
                order.OrderSum = checkedSum;

            }

            Order newOrder = await _OrderRepository.addOrder(order);
            if (newOrder != null)
                return newOrder;
            return null;
        }


    }
}
