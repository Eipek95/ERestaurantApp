namespace SignalR.API_Food_DtoLayer.OrderDto
{
    public class CreateOrderDto
    {
        public int CartId { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? DiscountCode { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; } = null!;
    }
}
