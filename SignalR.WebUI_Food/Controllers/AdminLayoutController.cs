using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.Models;
using SignalR.WEB_Food.ViewModels.UserViewModels;

namespace SignalR.WEB_Food.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminLayoutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Dashboard()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> UserList()
        {
            var userList = await _userManager.Users.ToListAsync();
            var userViewModelList = userList.Select(x => new ResultUserViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                UserName = x.UserName
            }).ToList();
            return View(userViewModelList);
        }


        public IActionResult Claims()
        {
            var userClaimList = User.Claims.Select(x => new ClaimViewModel
            {
                Issuer = x.Issuer,
                Type = x.Type,
                Value = x.Value
            }).ToList();
            return View(userClaimList);
        }
    }
}
