using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailByOrderId(int orderId)
        {
            var orderDetail = await _orderDetailService.BGetOrderDetailByOrderId(orderId);
            return Ok(orderDetail);
        }
    }
}
