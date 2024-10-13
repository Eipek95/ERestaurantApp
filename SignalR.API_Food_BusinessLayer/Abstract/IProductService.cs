using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> BGetProductsWithCategories();
        int BProductCount();
        int BGetProductCountWithCategoryNameForHamburger();
        int BGetProductCountWithCategoryNameForDrink();
        decimal BProductPriceAvg();
        string BProductNameByMaxPrice();
        string BProductNameByMinPrice();
        decimal BProductAvgPriceByHamburger();
        object BDateSaleProductInOrder(string date);
        object BGetWeeklySalesReport();
    }
}
