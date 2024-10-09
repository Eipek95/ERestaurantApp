namespace SignalR.API_Food_DtoLayer.CouponDto
{
    public class CreateCouponDto
    {
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public bool Status { get; set; }
    }
}
