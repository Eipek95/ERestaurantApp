using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public bool isUpdated { get; set; }

        public Product? Product { get; set; }
        [JsonIgnore]
        public Cart? Cart { get; set; }
    }
}
