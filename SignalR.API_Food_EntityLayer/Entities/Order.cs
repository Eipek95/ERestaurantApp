﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? DiscountCode { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; } = null!;
        [NotMapped]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
