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
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLayoutController(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
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

        [HttpGet]
        public async Task<IActionResult> Json1()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Category/StatisticsGetCategoriesWithProductCountAsync");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Json(jsonData);
        }


        public async Task<IActionResult> Json2(string date)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/Product/DateSaleProductInOrder?date={date}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Json(jsonData);
        }

        public async Task<IActionResult> Json3()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/Product/GetWeeklySalesReport");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Json(jsonData);
        }


        public async Task<IActionResult> Json4()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/Order/GetAll");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Json(jsonData);
        }

        public async Task<IActionResult> Json5(int orderId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/OrderDetail?orderId={orderId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Json(jsonData);
        }

        public async Task<IActionResult> Json6()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/Product/GetYearlySalesReport");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Json(jsonData);
        }
    }
}
