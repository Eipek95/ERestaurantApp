using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public IActionResult TotalOrderCount() => Ok(_orderService.BTotalOrderCount());
		[HttpGet("ActiveOrderCount")]
		public IActionResult ActiveOrderCount() => Ok(_orderService.BActiveOrderCount());
		[HttpGet("PassiveOrderCount")]
		public IActionResult PassiveOrderCount() => Ok(_orderService.BPassiveOrderCount());
		[HttpGet("LastOrderPrice")]
		public IActionResult LastOrderPrice() => Ok(_orderService.BLastOrderPrice());
		[HttpGet("TodayTotalPrice")]
		public IActionResult TodayTotalPrice() => Ok(_orderService.BTodayTotalPrice());

	}
}
