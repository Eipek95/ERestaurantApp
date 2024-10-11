namespace SignalR.API_Food_EntityLayer.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
