using Microsoft.AspNetCore.Mvc;

namespace SignalR.WEB_Food.ViewComponents.LayoutComponents
{
    public class _LayoutScriptPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
