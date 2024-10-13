using SignalR.WEB_Food.ViewModels.OrderViewModels;
using SignalR.WEB_Food.ViewModels.ProductViewModels;

namespace SignalR.WEB_Food.ViewModels.OrderDetailViewModels
{
    public class ResultOrderDetailViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public ResultOrderViewModel? Order { get; set; }
        public ResultProductViewModel? Product { get; set; }
    }
}
