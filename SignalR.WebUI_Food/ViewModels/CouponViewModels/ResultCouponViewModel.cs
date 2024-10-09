namespace SignalR.WEB_Food.ViewModels.CouponViewModels
{
    public class ResultCouponViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public bool Status { get; set; }
    }
}
