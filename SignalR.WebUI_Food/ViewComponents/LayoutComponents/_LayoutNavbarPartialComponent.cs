﻿using Microsoft.AspNetCore.Mvc;

namespace SignalR.WEB_Food.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
