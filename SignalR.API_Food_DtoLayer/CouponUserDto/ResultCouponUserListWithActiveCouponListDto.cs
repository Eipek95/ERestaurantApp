using SignalR.API_Food_DtoLayer.CouponDto;

namespace SignalR.API_Food_DtoLayer.CouponUserDto
{
    public class ResultCouponUserListWithActiveCouponListDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int CouponId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        //public string Code { get; set; } = null!;
        public ResultCouponDto Coupon { get; set; }
        public decimal CouponDiscountAmount { get; set; }

    }
}
