using Microsoft.AspNetCore.Mvc;

namespace SignalR.WEB_Food.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
