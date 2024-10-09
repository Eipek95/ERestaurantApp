using System.Text.Json.Serialization;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public string UserID { get; set; }
        [JsonIgnore]
        public AppUser User { get; set; }
    }
}
