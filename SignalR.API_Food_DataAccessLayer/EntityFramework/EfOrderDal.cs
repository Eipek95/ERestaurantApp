using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return 0;
            //return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public async Task<List<Order>> GetOrderByOrderStatus(string orderStatus)
        {
            using var context = new SignalRContext();
            var orders = await context.Orders.Include(x => x.OrderDetails).Where(x => x.OrderStatus == orderStatus).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetOrderByUserId(string userId)
        {
            using var context = new SignalRContext();
            var orders = await context.Orders.Include(x => x.OrderDetails).ThenInclude(y => y.Product).Where(x => x.UserId == userId).ToListAsync();
            return orders;
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return 0;
            //return context.Orders.OrderByDescending(x => x.Id).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public int PassiveOrderCount()
        {
            using var context = new SignalRContext();
            return 0;
            // return context.Orders.Where(x => x.Description == "Hesap Ödendi").Count();
        }

        public async Task SaveOrder(Order order)
        {
            using var context = new SignalRContext();
            await context.Orders.AddAsync(order);


            var orderId = order.Id;
            foreach (var item in order.OrderDetails)
            {
                item.OrderId = orderId;
            }
            await context.OrderDetails.AddRangeAsync(order.OrderDetails);
            await context.SaveChangesAsync();
        }

        public int SellingProductCount()
        {
            var today = DateTime.Today.Date;
            using var context = new SignalRContext();
            // Günlük satılan toplam ürün sayısını almak
            var totalProductsSoldToday = context.OrderDetails
                .Where(od => od.Order.Date.Date == today) // Bugüne ait siparişler
                .Sum(od => od.Quantity); // Toplam satılan ürün sayısı
            return totalProductsSoldToday;
        }

        public decimal TodayTotalPrice()
        {
            var today = DateTime.Today.Date;
            using var context = new SignalRContext();
            var totalPrice = context.Orders.Where(x => x.Date.Date == today).Sum(o => o.DiscountCode == "yok" ? o.Price : (o.DiscountPrice.HasValue ? o.DiscountPrice.Value : o.Price));
            return totalPrice;
        }

        public string TopSellingProduct()
        {
            var today = DateTime.Today.Date;
            using var context = new SignalRContext();
            // Günün siparişlerinden en çok satılan ürünü almak
            var topSellingProduct = context.OrderDetails
                .Where(od => od.Order.Date.Date == today) // Bugüne ait siparişler
                .GroupBy(od => od.Product) // Ürün bazında gruplama
                .Select(g => new
                {
                    Product = g.Key, // Ürün
                    TotalQuantity = g.Sum(od => od.Quantity) // Toplam satılan miktar
                })
                .OrderByDescending(g => g.TotalQuantity) // En çok satılan ürüne göre sıralama
                .FirstOrDefault().Product.Name; // En çok satılan ürünü al

            return topSellingProduct;
        }

        public int TotalOrderCount()
        {
            var today = DateTime.Now.Date;
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Date.Date == today).Count();
        }
    }
}
