using SignalR.API_Food_DtoLayer.OrderDetailDto;

namespace SignalR.API_Food_DtoLayer.OrderDto
{
    public class ResultOrderDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? DiscountCode { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; } = null!;
        public string? OrderStatus { get; set; }
        public List<ResultOrderDetailDto>? OrderDetails { get; set; }
    }
}
