using System.Text.Json.Serialization;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public List<CouponUser> CouponUsers { get; set; }
    }
}
