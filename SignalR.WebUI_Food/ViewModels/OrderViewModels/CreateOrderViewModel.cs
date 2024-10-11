using SignalR.WEB_Food.ViewModels.OrderDetailViewModels;

namespace SignalR.WEB_Food.ViewModels.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public int CartId { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? DiscountCode { get; set; }
        public string UserId { get; set; } = null!;
        public string? OrderStatus { get; set; }
        public DateTime Date { get; set; }
        public List<CreateOrderDetailViewModel> OrderDetails { get; set; } = new List<CreateOrderDetailViewModel>();
    }
}
