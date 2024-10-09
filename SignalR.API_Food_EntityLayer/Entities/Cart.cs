using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public string DiscountCode { get; set; }
        public decimal DiscountRate { get; set; }
        [NotMapped]
        public bool isCouponUpdate { get; set; }

        //public decimal TotalPrice
        //{
        //    get => CartItems.Sum(x => x.Quantity * x.Product.Price);
        //}
    }
}
