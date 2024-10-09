using Microsoft.AspNetCore.Mvc;

namespace SignalR.WEB_Food.ViewComponents.LayoutComponents
{
    public class _LayoutFooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
