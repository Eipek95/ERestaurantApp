using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class CouponManager : ICouponService
    {
        private readonly ICouponDal _couponDal;

        public CouponManager(ICouponDal couponDal)
        {
            _couponDal = couponDal;
        }

        public void BAdd(Coupon entity) => _couponDal.Add(entity);

        public void BDelete(Coupon entity) => _couponDal.Delete(entity);

        public List<Coupon> BGetAll() => _couponDal.GetAll();

        public Coupon BGetById(int id) => _couponDal.GetById(id);

        public void BUpdate(Coupon entity) => _couponDal.Update(entity);
    }
}
