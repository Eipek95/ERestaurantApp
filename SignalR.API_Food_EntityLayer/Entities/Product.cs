﻿using System.Text.Json.Serialization;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        [JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
        [JsonIgnore]
        public List<Basket>? Baskets { get; set; }
    }
}
