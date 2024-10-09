namespace SignalR.WEB_Food.ViewModels.BasketViewModels
{
    public class BasketViewModel
    {
        public int BasketId { get; set; }
        public List<ResultBasketViewModel> BasketItems { get; set; }

        public decimal DiscountAmount { get; set; }
        public decimal TotalPriceFunction()
        {
            return BasketItems.Sum(x => x.Price * x.Count);
        }


        public decimal TotalPriceWithTaxFunction()
        {

            decimal TotalPriceWithTax = TotalPriceFunction() + TotalPriceFunction() * 10 / 100;
            return TotalPriceWithTax;
        }

        public decimal TotalDiscountAmountFunction()
        {

            decimal TotalPriceWithTax = TotalPriceFunction() * DiscountAmount / 100;
            return Math.Round(TotalPriceWithTax, 2);
        }
        public decimal TotalPriceWithTaxDiscountFunction()
        {

            decimal TotalPriceWithTax = TotalPriceWithTaxFunction() - (TotalPriceFunction() * DiscountAmount / 100);
            return Math.Round(TotalPriceWithTax, 2);
        }
    }
}
