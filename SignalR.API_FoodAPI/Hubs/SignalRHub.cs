using Microsoft.AspNetCore.SignalR;
using SignalR.API_Food_BusinessLayer.Abstract;

namespace SignalR.API_FoodAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }




        public async Task SendProgress()
        {


            var values7 = _orderService.BTodayTotalPrice();
            await Clients.All.SendAsync("RecieveGetTodayTotalPrice", values7);

            var values8 = _orderService.BTotalOrderCount();
            await Clients.All.SendAsync("RecieveGetTodayOrderCount", values8);


            var values9 = _orderService.BTopSellingProduct();
            await Clients.All.SendAsync("RecieveGetTopSellingProduct", values9);

            var values10 = _orderService.BSellingProductCount();
            await Clients.All.SendAsync("RecieveGetSellingProductCount", values10);

            var values11 = await _categoryService.BGetCategoriesWithProductCountAsync();
            await Clients.All.SendAsync("RecieveGetCategoriesWithProductCountAsync", values11);

            var values12 = _productService.BGetWeeklySalesReport();
            await Clients.All.SendAsync("RecieveGetWeeklySalesReport", values12);

            var values13 = _productService.BGetYearlySalesReport();
            await Clients.All.SendAsync("RecieveGetYearlySalesReport", values13);

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
