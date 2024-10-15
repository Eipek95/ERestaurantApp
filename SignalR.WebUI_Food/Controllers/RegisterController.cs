using Bogus;
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



        public async Task<IActionResult> SaveAccount()
        {
            var faker = new Faker();
            var password = "password123*";
            int count = 0;
            var client = _httpClientFactory.CreateClient();
            for (int i = 0; i < 10; i++)
            {
                count++;
                var firstName = faker.Name.FirstName();
                var lastName = faker.Name.LastName();
                var appUser = new AppUser
                {
                    Name = firstName,
                    Surname = lastName,
                    Email = faker.Internet.Email(firstName + $"{count}", lastName, "example.com"),
                    UserName = "username" + count,
                    Gender = Gender.Belirtilmedi,
                    City = faker.Person.Address.City,
                };

                var result = await _userManager.CreateAsync(appUser, password);

                if (result.Succeeded)
                {
                    var responseMessage2 = await client.GetAsync($"https://localhost:7146/api/Cart/InitializeCart?userId={appUser.Id}");
                }
            }
            return Json("İşlem Başarıyla Gerçekleşti");
        }
    }
}
