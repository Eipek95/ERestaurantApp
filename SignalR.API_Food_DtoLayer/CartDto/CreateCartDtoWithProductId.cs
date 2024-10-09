namespace SignalR.API_Food_DtoLayer.CartDto
{
    public class CreateCartDtoWithProductId
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
