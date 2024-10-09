using SignalR.API_Food_DtoLayer.ProductDto;

namespace SignalR.API_Food_DtoLayer.CartItemDto
{
    public class ResultCartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ResultProductDto Product { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
