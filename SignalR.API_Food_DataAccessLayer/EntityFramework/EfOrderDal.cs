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
			return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.OrderByDescending(x => x.Id).Take(1).Select(y => y.TotalPrice).FirstOrDefault();
		}

		public int PassiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x => x.Description == "Hesap Ödendi").Count();
		}

		public decimal TodayTotalPrice()
		{
			using var context = new SignalRContext();
			var nowDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			var values = context.Orders.Where(x => x.Date == nowDate && x.Description == "Hesap Ödendi").Sum(y => y.TotalPrice);
			return values;
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Count();
		}
	}
}
