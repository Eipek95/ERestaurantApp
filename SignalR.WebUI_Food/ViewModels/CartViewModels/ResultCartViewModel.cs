using SignalR.WEB_Food.ViewModels.CartItemViewModels;

namespace SignalR.WEB_Food.ViewModels.CartViewModels
{
    public class ResultCartViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? DiscountCode { get; set; }
        public decimal DiscountRate { get; set; }
        public bool isCouponUpdate { get; set; }
        public List<ResultCartItemViewModel> CartItems { get; set; }

        public decimal UpTotalPrice
        {
            get
            {
                decimal totalPrice = TotalPrice();
                if (HasDiscount)
                {
                    if (DiscountRate > 0)
                    {
                        decimal discountAmount = totalPrice * ((decimal)DiscountRate / 100);
                        totalPrice -= discountAmount;
                    }
                }
                return totalPrice;
            }
        }


        public decimal TotalPrice()
        {
            return CartItems.Sum(x => x.Quantity * x.Product.Price);
        }
        public bool HasDiscount
        {
            get => !string.IsNullOrEmpty(DiscountCode);
        }

    }
}
