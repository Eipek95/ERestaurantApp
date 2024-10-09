using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.ViewModels.CartItemViewModels;
using SignalR.WEB_Food.ViewModels.CartViewModels;
using SignalR.WEB_Food.ViewModels.CategoryViewModels;
using SignalR.WEB_Food.ViewModels.ProductViewModels;
using System.Security.Claims;
using System.Text;

namespace SignalR.WEB_Food.Controllers
{
    public class MenuController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public MenuController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductViewModel>>(jsonData);


            var responseMessage2 = await client.GetAsync("https://localhost:7146/api/Category");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(jsonData2);


            var tupleModel = new Tuple<List<ResultProductViewModel>, List<ResultCategoryViewModel>>(values, values2);
            return View(tupleModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] AddToCartViewModel addToCartViewModel)
        {
            var currentUserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (currentUserId?.Value == null)
            {
                return Json(false);
            }

            ResultCartItemViewModel item = new ResultCartItemViewModel();
            item.ProductId = addToCartViewModel.productId;
            item.Quantity = addToCartViewModel.quantity;
            await AddBasketItem(item);


            return Json(addToCartViewModel);
        }


        public async Task<IActionResult> DeleteBasket(int productId)
        {

            var currentUserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var values = await GetCart(currentUserId.Value);
            var deletedItem = values.CartItems.FirstOrDefault(x => x.ProductId == productId);


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(
                $"https://localhost:7146/api/Cart?cartId={values.Id}&productId={productId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Basket");
            }
            return NoContent();
        }

        //service 
        private async Task<ResultCartViewModel> GetCart(string userId)
        {
            var client = _httpClientFactory.CreateClient();

            //sepet bilgilerini getir
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Cart?userId=" + userId);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultCartViewModel>(jsonData);

            return values!;
        }

        private async Task AddBasketItem(ResultCartItemViewModel cartItemViewModel)
        {
            var currentUserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var values = await GetCart(currentUserId.Value);

            var client = _httpClientFactory.CreateClient();

            //ürün bilgilerini getir
            var responseMessage = await client.GetAsync("https://localhost:7146/api/Product/" + cartItemViewModel.ProductId);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ResultProductViewModel>(jsonData);


            if (values.CartItems.Count == 0)
            {
                values.CartItems.Add(new ResultCartItemViewModel
                {
                    CartId = values.Id,
                    ProductId = cartItemViewModel.ProductId,
                    Quantity = cartItemViewModel.Quantity,
                    Price = product!.Price,
                    Product = product,
                    isUpdated = false
                });
            }
            else
            {
                if (!values.CartItems.Any(x => x.ProductId == cartItemViewModel.ProductId))
                {
                    values.CartItems.Add(new ResultCartItemViewModel
                    {
                        CartId = values.Id,
                        ProductId = cartItemViewModel.ProductId,
                        Quantity = cartItemViewModel.Quantity,
                        Price = product!.Price,
                        Product = product,
                        isUpdated = false
                    });
                }
                else
                {
                    var existingItem = values.CartItems.First(x => x.ProductId == cartItemViewModel.ProductId);
                    existingItem.Quantity += cartItemViewModel.Quantity;
                    existingItem.isUpdated = true;
                }
            }

            //save işlemi


            var jsonData2 = JsonConvert.SerializeObject(values);
            StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PostAsync("https://localhost:7146/api/Cart/", stringContent);
            if (responseMessage2.IsSuccessStatusCode)
            {
            }
        }
    }

}

