namespace SignalR.WEB_Food.ViewModels.CouponUserViewModels
{
    public class UpdateCouponUserViewModel
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int CouponId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
