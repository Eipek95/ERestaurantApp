using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCaseController : ControllerBase
	{
		private IMoneyCaseService _moneyCaseService;

		public MoneyCaseController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}

		[HttpGet("TotalMoneyCaseAmount")]
		public IActionResult TotalMoneyCaseAmount() => Ok(_moneyCaseService.BTotalMoneyCaseAmount());
	}
}
