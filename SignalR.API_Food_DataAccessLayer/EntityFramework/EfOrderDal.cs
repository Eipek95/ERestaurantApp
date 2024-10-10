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

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            return 0;
            //var nowDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //var values = context.Orders.Where(x => x.Date == nowDate && x.Description == "Hesap Ödendi").Sum(y => y.TotalPrice);
            //return values;
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
