using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();

        int GetProductCountWithCategoryNameForHamburger();
        int GetProductCountWithCategoryNameForDrink();
        decimal ProductPriceAvg();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductAvgPriceByHamburger();
        object DateSaleProductInOrder(string date);
        object GetWeeklySalesReport();
    }
}
