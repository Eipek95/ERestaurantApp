namespace SignalR.API_Food_DtoLayer.BasketDto
{
    public class ResultBasketDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public string UserID { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
