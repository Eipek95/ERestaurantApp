using Microsoft.AspNetCore.Mvc;

namespace SignalR.WEB_Food.ViewComponents.DefaultComponents
{
	public class _DefaultBookATableComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
