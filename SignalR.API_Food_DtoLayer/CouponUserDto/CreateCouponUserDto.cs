namespace SignalR.API_Food_DtoLayer.CouponUserDto
{
    public class CreateCouponUserDto
    {
        public string AppUserId { get; set; }
        public int CouponId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
