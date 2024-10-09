using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.API_Common;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.Extensions;
using SignalR.WEB_Food.ViewModels.CartViewModels;
using SignalR.WEB_Food.ViewModels.IdentityViewModels;
using System.Text;

namespace SignalR.WEB_Food.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            var appUser = new AppUser
            {
                Name = registerViewModel.Name,
                Surname = registerViewModel.Surname,
                Email = registerViewModel.Mail,
                UserName = registerViewModel.Username,
                Gender = Gender.Belirtilmedi,
                City = "İstanbul"
            };

            var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
            if (result.Succeeded)
            {

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(new CreateCartViewModel
                {
                    UserId = appUser.Id
                });
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7146/api/Cart", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Üyelik kayıt işlemi başarıyla gerçekleşmiştir.";
                    return RedirectToAction(nameof(AccountController.Login), "Account");
                }

            }

            ModelState.AddModelErrorList(result.Errors);

            return View();
        }
    }
}
