using Entites;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;

namespace pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService IOrderService, IMapper mapper)
        {
            _mapper = mapper;
            _OrderService = IOrderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDto)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDto);
            Order newOrder = await _OrderService.addOrder(order);
            OrderDTO newOrderDto = _mapper.Map<Order, OrderDTO>(newOrder);
            return newOrderDto;
        }

    }
}
