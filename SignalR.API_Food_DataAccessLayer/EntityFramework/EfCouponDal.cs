using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfCouponDal : GenericRepository<Coupon>, ICouponDal
    {
        public EfCouponDal(SignalRContext context) : base(context)
        {
        }
    }
}
