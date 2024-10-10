using SignalR.API_Food_DtoLayer.ProductDto;

namespace SignalR.API_Food_DtoLayer.OrderDetailDto
{
    public class ResultOrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public ResultProductDto? Product { get; set; }
    }
}
