namespace SignalR.API_Food_DtoLayer.CouponDto
{
    public class UpdateCouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public bool Status { get; set; }
    }
}
