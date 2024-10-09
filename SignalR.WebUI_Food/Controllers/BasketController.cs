using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.ViewModels.CartViewModels;
using SignalR.WEB_Food.ViewModels.CouponUserViewModels;
using System.Security.Claims;
using System.Text;

namespace SignalR.WEB_Food.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;
        public BasketController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string code = "0")
        {
            var cart = await GetCart();
            if (code == "0")
            {

            }
            else
            {
                var deg = await ApplyDiscount(code);
                cart.DiscountCode = deg.Keys.First();
                cart.DiscountRate = deg.Values.First();
            }

            return View(cart);

        }

        public async Task<IActionResult> CancelDiscount()
        {
            await CancelApplyDiscount();
            return RedirectToAction("Index");
        }

        private async Task<ResultCartViewModel> GetCart()
        {
            var currentUser = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Cart?userId=" + currentUser?.Value);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultCartViewModel>(jsonData);
            return values!;
        }

        public async Task<Dictionary<string, decimal>> ApplyDiscount(string couponCode)
        {
            await CancelApplyDiscount();
            var newDictionary = new Dictionary<string, decimal>();
            var currentCart = await GetCart();

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($" https://localhost:7146/api/CouponUser/GetCodeAvailable?code={couponCode}&userId={currentCart.UserId}");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var hasDiscount = JsonConvert.DeserializeObject<ResultCouponUserListWithActiveCouponListViewModel>(jsonData2);


            if (hasDiscount != null)
            {
                currentCart.isCouponUpdate = true;
                currentCart.DiscountCode = hasDiscount.Coupon.Code;
                currentCart.DiscountRate = hasDiscount.CouponDiscountAmount;

                var jsonData3 = JsonConvert.SerializeObject(currentCart);
                StringContent stringContent = new StringContent(jsonData3, Encoding.UTF8, "application/json");
                var responseMessage3 = await client.PostAsync("https://localhost:7146/api/Cart/", stringContent);
                newDictionary.Add(hasDiscount.Coupon.Code, hasDiscount.CouponDiscountAmount);
            }

            else
            {
                newDictionary.Add(currentCart.DiscountCode, currentCart.DiscountRate);
            }
            return newDictionary;
        }

        public async Task<Dictionary<string, decimal>> CancelApplyDiscount()
        {
            var client = _httpClientFactory.CreateClient();
            var currentCart = await GetCart();
            currentCart.isCouponUpdate = true;
            currentCart.DiscountCode = "yok";
            currentCart.DiscountRate = 0;
            var jsonData2 = JsonConvert.SerializeObject(currentCart);
            StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PostAsync("https://localhost:7146/api/Cart/", stringContent);
            var newDictionary = new Dictionary<string, decimal>();
            newDictionary.Add(currentCart.DiscountCode, currentCart.DiscountRate);
            return newDictionary;
        }
    }
}