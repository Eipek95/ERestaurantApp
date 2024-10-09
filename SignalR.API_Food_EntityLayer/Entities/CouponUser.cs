using System.Text.Json.Serialization;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class CouponUser
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        [JsonIgnore]
        public AppUser AppUser { get; set; }
        public int CouponId { get; set; }
        [JsonIgnore]
        public Coupon Coupon { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
