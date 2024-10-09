using SignalR.API_Food_DtoLayer.CartItemDto;

namespace SignalR.API_Food_DtoLayer.CartDto
{
    public class ResultCartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<ResultCartItemDto> CartItems { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }

        public decimal TotalPrice
        {
            get => CartItems.Sum(x => x.Product.Price * x.Quantity);
        }
    }
}
