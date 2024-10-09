using Microsoft.AspNetCore.Mvc;

namespace SignalR.WEB_Food.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
