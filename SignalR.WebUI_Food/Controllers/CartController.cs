using IyzipayCore;
using IyzipayCore.Model;
using IyzipayCore.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.API_Food_EntityLayer.Entities;
using SignalR.WEB_Food.ViewModels.BasketViewModels;
using SignalR.WEB_Food.ViewModels.CardViewModels;
using SignalR.WEB_Food.ViewModels.CartViewModels;
using System.Security.Claims;

namespace SignalR.WEB_Food.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public CartController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var basket = await GetCart();
            if (currentUser == null)
            {
                return NotFound();
            }
            CardViewModel cardViewModel = new CardViewModel()
            {
                FirstName = currentUser.Name,
                LastName = currentUser.Surname,
                City = currentUser.City,
                Phone = currentUser.PhoneNumber,
                Email = currentUser.Email,
                UserId = currentUser.Id,
                TotalPrice = basket.UpTotalPrice,
                BasketId = basket.Id.ToString()
            };
            return View(cardViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(CartController.Index), "Cart");
            }

            var currentUser = await _userManager.GetUserAsync(User);

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7146/api/Basket/{currentUser!.Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketViewModel>>(jsonData);



            }
            var payment = await PaymentProcess(model);


            if (payment.Status == "failure")
            {

                return RedirectToAction("StatusPayment", new { statusCode = false, statusMessage = payment.ErrorMessage });

            }


            return RedirectToAction("StatusPayment", new { statusCode = true });
        }


        public IActionResult StatusPayment(bool statusCode, string? statusMessage)
        {
            if (!statusCode)
            {
                ViewBag.StatusErrorMessage = statusMessage;
                return View();
            }

            return View();
        }

        private async Task<Payment> PaymentProcess(CardViewModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-seMYGizyKfsVVTF8w8oPMjqicUWW3AeI";
            options.SecretKey = "ru0eYt7Z9rTT8LyczNfXzzsPTDO39gPb";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = Guid.NewGuid().ToString();
            request.Price = model.TotalPrice.ToString("#.##").Replace(",", ".");
            request.PaidPrice = model.TotalPrice.ToString("#.##").Replace(",", ".");//vergili fiyat
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;//taksit 
            request.BasketId = model.BasketId.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvv;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;



            List<BasketItem> items = new List<BasketItem>();
            BasketItem basketItem;

            var basket = await GetCart();
            foreach (var item in basket.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = model.BasketId.ToString();
                basketItem.Name = item.Product.Name.ToString();
                basketItem.Category1 = "Yiyecek/İçecek";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = ((item.Product.Price - (item.Product.Price * basket.DiscountRate / 100)) * item.Quantity).ToString("#.##").Replace(",", ".");
                items.Add(basketItem);
            }

            request.BasketItems = items;
            return Payment.Create(request, options);

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
    }
}
