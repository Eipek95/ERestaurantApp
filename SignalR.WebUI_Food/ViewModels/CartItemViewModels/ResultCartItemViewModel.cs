using SignalR.WEB_Food.ViewModels.ProductViewModels;
using System.Text.Json.Serialization;

namespace SignalR.WEB_Food.ViewModels.CartItemViewModels
{
    public class ResultCartItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ResultProductViewModel Product { get; set; }
        [JsonIgnore]
        public bool isUpdated { get; set; }
    }
}
