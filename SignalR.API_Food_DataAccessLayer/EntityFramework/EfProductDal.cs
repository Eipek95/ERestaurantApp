using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_DtoLayer.ProductDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }



        public int GetProductCountWithCategoryNameForDrink()
        {
            var context = new SignalRContext();
            var values = context.Products.Where(
                x => x.Category.Name == (context.Categories.Where(y => y.Id == 5).Select(x => x.Name).FirstOrDefault())).Count();
            return values;
        }

        public int GetProductCountWithCategoryNameForHamburger()
        {
            var context = new SignalRContext();
            var values = context.Products.Where(
                x => x.Category.Name == (context.Categories.Where(y => y.Id == 1).Select(x => x.Name).FirstOrDefault())).Count();
            return values;
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            var context = new SignalRContext();
            var values = context.Products.Count();
            return values;
        }

        public string ProductNameByMaxPrice()
        {
            var context = new SignalRContext();
            var values = context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.Name).FirstOrDefault();
            return values!;
        }

        public string ProductNameByMinPrice()
        {
            var context = new SignalRContext();
            var values = context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.Name).FirstOrDefault();
            return values!;
        }

        public decimal ProductPriceAvg()
        {
            var context = new SignalRContext();
            var values = context.Products.Average(x => x.Price);
            return values;
        }

        public decimal ProductAvgPriceByHamburger()
        {
            var context = new SignalRContext();
            var values = context.Products.Where(
                x => x.Category.Id == (context.Categories.Where(y => y.Name == "Hamburger").Select(x => x.Id).FirstOrDefault())).Average(z => z.Price);
            return values;
        }

        public object DateSaleProductInOrder(string date)
        {
            var context = new SignalRContext();
            var convertDate = Convert.ToDateTime(date).Date;

            var soldProductsToday = context.Products.GroupJoin(context.OrderDetails.
                Where(o => o.Order.Date.Date == convertDate), p => p.Id, // Product Id'si üzerinden birleştirme
                 od => od.ProductID, // OrderDetail'deki ProductID ile eşleştir
                      (product, orderDetails) => new
                      {
                          ProductId = product.Id,
                          ProductName = product.Name,
                          TotalQuantitySold = orderDetails.Sum(od => (int?)od.Quantity) ?? 0 // Satış yoksa 0 al
                      }
                  ).ToList();
            return soldProductsToday;
        }

        public object GetWeeklySalesReport()
        {
            var context = new SignalRContext();


            DateTime today = DateTime.Today; // Bugünün tarihini al ve haftanın ilk günü olan pazartesiye git
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime startOfWeek = today.AddDays(-1 * diff).Date; // Haftanın başı (pazartesi)
            DateTime endOfWeek = today > startOfWeek.AddDays(6) ? today : startOfWeek.AddDays(6); // Bugünü de dahil et


            var weekDays = Enumerable.Range(0, (endOfWeek - startOfWeek).Days + 1) // Haftanın tüm günlerini oluştur
                .Select(d => startOfWeek.AddDays(d))
                .ToList();


            var salesData = context.OrderDetails // Veritabanından bu haftanın satışlarını çek
                .Where(od => od.Order.Date.Date >= startOfWeek.Date && od.Order.Date.Date <= endOfWeek.Date)
                .GroupBy(od => od.Order.Date.Date.Date) // Günlük gruplama
                .Select(g => new
                {
                    Date = g.Key,
                    TotalQuantitySold = g.Sum(od => od.Quantity) // O gün satılan toplam ürün sayısı
                })
                .ToList();


            var weeklySales = weekDays // Haftanın her günü için satış verilerini hazırla
                .GroupJoin(salesData,
                           day => day,
                           sale => sale.Date,
                           (day, sales) => new
                           {
                               Date = day,
                               TotalQuantitySold = sales.Sum(s => s.TotalQuantitySold) // Satış yoksa 0 döner
                           })
                .ToList();
            return weeklySales;
        }

        public List<MonthlySalesReport> GetYearlySalesReport()
        {
            var context = new SignalRContext();
            var year = DateTime.Now.Year;


            var monthlySales = Enumerable.Range(1, 12)
           .Select(month => new MonthlySalesReport
           {
               Month = new DateTime(year, month, 1).ToString("MMMM"),
               TotalSales = 0
           }).ToList();

            var salesData = context.Orders
             .Where(o => o.Date.Year == year)
             .GroupBy(o => o.Date.Month)
             .Select(g => new
             {
                 Month = g.Key,
                 TotalSales = g.Sum(o =>
                     o.DiscountCode == "yok"
                         ? o.Price
                         : (o.DiscountPrice.HasValue ? o.DiscountPrice.Value : o.Price))
             })
             .ToList();

            // Elde edilen satış verilerini ilgili aya ekliyoruz
            foreach (var data in salesData)
            {
                var monthReport = monthlySales.FirstOrDefault(m => m.Month == new DateTime(year, data.Month, 1).ToString("MMMM"));
                if (monthReport != null)
                {
                    monthReport.TotalSales = data.TotalSales;
                }
            }

            return monthlySales;
        }
    }
}
