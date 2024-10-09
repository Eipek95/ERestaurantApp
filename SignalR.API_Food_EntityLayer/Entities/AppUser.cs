using Microsoft.AspNetCore.Identity;
using SignalR.API_Common;
using System.Text.Json.Serialization;

namespace SignalR.API_Food_EntityLayer.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        [JsonIgnore]
        public List<Basket> Baskets { get; set; }

        [JsonIgnore]
        public List<CouponUser> CouponUsers { get; set; }
    }
}
