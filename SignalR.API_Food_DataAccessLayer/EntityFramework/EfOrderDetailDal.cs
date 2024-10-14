using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailDal(SignalRContext context) : base(context)
        {
        }

        public async Task<List<OrderDetail>> GetOrderDetailByOrderId(int orderId)
        {
            using var context = new SignalRContext();
            var orderDetail = await context.OrderDetails.Where(x => x.OrderId == orderId).Include(x => x.Product).ToListAsync();
            return orderDetail;
        }
    }
}
