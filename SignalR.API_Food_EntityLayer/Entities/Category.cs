using System.Text.Json.Serialization;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
