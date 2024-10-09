using Microsoft.AspNetCore.Mvc;

namespace SignalR.WEB_Food.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
