using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.OrderDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount() => Ok(_orderService.BTotalOrderCount());
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount() => Ok(_orderService.BActiveOrderCount());
        [HttpGet("PassiveOrderCount")]
        public IActionResult PassiveOrderCount() => Ok(_orderService.BPassiveOrderCount());
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice() => Ok(_orderService.BLastOrderPrice());
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice() => Ok(_orderService.BTodayTotalPrice());

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderDto orderDto)
        {
            orderDto.Date = DateTime.Now;
            var order = _mapper.Map<Order>(orderDto);
            await _orderService.BSaveOrder(order);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderByOrderStatus(string orderStatus)
        {
            var order = await _orderService.BGetOrderByOrderStatus(orderStatus);
            return Ok(order);
        }
    }
}
