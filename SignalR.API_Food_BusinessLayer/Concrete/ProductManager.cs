using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DtoLayer.ProductDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void BAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void BDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> BGetAll()
        {
            return _productDal.GetAll();
        }

        public Product BGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public int BGetProductCountWithCategoryNameForDrink() => _productDal.GetProductCountWithCategoryNameForDrink();

        public int BGetProductCountWithCategoryNameForHamburger() => _productDal.GetProductCountWithCategoryNameForHamburger();

        public List<Product> BGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public int BProductCount() => _productDal.ProductCount();

        public decimal BProductPriceAvg() => _productDal.ProductPriceAvg();

        public void BUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public string BProductNameByMaxPrice() => _productDal.ProductNameByMaxPrice();

        public string BProductNameByMinPrice() => _productDal.ProductNameByMinPrice();

        public decimal BProductAvgPriceByHamburger() => _productDal.ProductAvgPriceByHamburger();

        public object BDateSaleProductInOrder(string date) => _productDal.DateSaleProductInOrder(date);

        public object BGetWeeklySalesReport() => _productDal.GetWeeklySalesReport();

        public List<MonthlySalesReport> BGetYearlySalesReport() => _productDal.GetYearlySalesReport();
    }
}
