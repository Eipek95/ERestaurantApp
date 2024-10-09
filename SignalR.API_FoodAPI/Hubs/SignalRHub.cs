using Microsoft.AspNetCore.SignalR;
using SignalR.API_Food_BusinessLayer.Abstract;

namespace SignalR.API_FoodAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatisticsCount()
        {
            //categories
            var values = _categoryService.BGetCategoryCount();
            var values3 = _categoryService.BGetActiveCategoryCount();
            var values4 = _categoryService.BGetPassiveCategoryCount();

            //products
            var values2 = _productService.BProductCount();
            var values5 = _productService.BGetProductCountWithCategoryNameForHamburger();
            var values6 = _productService.BGetProductCountWithCategoryNameForDrink();
            var values7 = _productService.BProductPriceAvg();
            var values8 = _productService.BProductNameByMaxPrice();
            var values9 = _productService.BProductNameByMinPrice();
            var values10 = _productService.BProductAvgPriceByHamburger();


            //order
            var values11 = _orderService.BTotalOrderCount();
            var values12 = _orderService.BActiveOrderCount();
            var values13 = _orderService.BLastOrderPrice();
            var values15 = _orderService.BTodayTotalPrice();


            //moneycase
            var values14 = _moneyCaseService.BTotalMoneyCaseAmount();


            //menutable
            var values16 = _menuTableService.BMenuTableCount();


            await Clients.All.SendAsync("RecieveCategoryCount", values);
            await Clients.All.SendAsync("RecieveActiveCategoryCount", values3);
            await Clients.All.SendAsync("RecievePassiveCategoryCount", values4);
            await Clients.All.SendAsync("RecieveProductCount", values2);
            await Clients.All.SendAsync("RecieveProductCountWithCategoryNameForHamburger", values5);
            await Clients.All.SendAsync("RecieveProductCountWithCategoryNameForDrink", values6);
            await Clients.All.SendAsync("RecieveProductPriceAvg", values7);
            await Clients.All.SendAsync("RecieveProductNameByMaxPrice", values8);
            await Clients.All.SendAsync("RecieveProductNameByMinPrice", values9);
            await Clients.All.SendAsync("RecieveProductAvgPriceByHamburger", values10);
            await Clients.All.SendAsync("RecieveTotalOrderCount", values11);
            await Clients.All.SendAsync("RecieveActiveOrderCount", values12);
            await Clients.All.SendAsync("RecieveLastOrderPrice", values13);
            await Clients.All.SendAsync("RecieveTotalMoneyCaseAmount", values14);
            await Clients.All.SendAsync("RecieveTodayTotalPrice", values15);
            await Clients.All.SendAsync("RecieveMenuTableCount", values16);
        }


        public async Task SendProgress()
        {
            var values = _moneyCaseService.BTotalMoneyCaseAmount();
            await Clients.All.SendAsync("RecieveTotalMoneyCaseAmount", values);


            var values2 = _orderService.BActiveOrderCount();
            await Clients.All.SendAsync("RecieveActiveOrderCount", values2);

            var values3 = _menuTableService.BMenuTableCount();
            await Clients.All.SendAsync("RecieveMenuTableCount", values3);

            var values4 = _productService.BProductPriceAvg();
            await Clients.All.SendAsync("RecieveProductPriceAvg", values4);

            var values5 = _productService.BProductAvgPriceByHamburger();
            await Clients.All.SendAsync("RecieveProductAvgPriceByHamburger", values5);


            var values6 = _productService.BGetProductCountWithCategoryNameForDrink();
            await Clients.All.SendAsync("RecieveGetProductCountWithCategoryNameForDrink", values6);

            //Random rnd = new Random();
            //while (true)
            //{
            //    while (true)
            //    {
            //        int randomNumber = rnd.Next(0, 101);
            //        await Clients.All.SendAsync("RecieveRandomGenerator", randomNumber);
            //        Thread.Sleep(10000); // 10 saniye bekle
            //    }
            //}
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.BGetAll().Where(x => x.Status == "Alındı");
            await Clients.All.SendAsync("PendingBookings", values);


            var values2 = _bookingService.BGetAll().Where(x => x.Status == "Onaylandı");
            await Clients.All.SendAsync("ConfirmedBookings", values2);


            var values3 = _bookingService.BGetAll().Where(x => x.Status == "İptal");
            await Clients.All.SendAsync("CancelledBookings", values3);
        }


        public async Task SendNotification()
        {
            var value = _notificationService.BNotificationCountByStatusFalse();
            await Clients.All.SendAsync("RecieveNotificationCountByStatusFalse", value);

            var values = _notificationService.BGetAllNotificationByFalse();
            await Clients.All.SendAsync("RecieveAllNotificationByStatusFalse", values);

        }


        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.BGetAll();
            await Clients.All.SendAsync("RecieveGetMenuTableStatus", value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }

    }
}
