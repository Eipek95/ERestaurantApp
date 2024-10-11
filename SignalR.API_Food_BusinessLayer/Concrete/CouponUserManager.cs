using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class CouponUserManager : ICouponUserService
    {
        private readonly ICouponUserDal _couponUserDal;

        public CouponUserManager(ICouponUserDal couponUserDal)
        {
            _couponUserDal = couponUserDal;
        }

        public void BAdd(CouponUser entity) => _couponUserDal.Add(entity);

        public void BAddList(List<CouponUser> couponUsers) => _couponUserDal.AddList(couponUsers);

        public void BDelete(CouponUser entity) => _couponUserDal.Delete(entity);

        public List<CouponUser> BGetAll() => _couponUserDal.GetAll();

        public CouponUser BGetById(int id) => _couponUserDal.GetById(id);



        public List<CouponUser> BGetCouponUserList(int id) => _couponUserDal.GetCouponUserList(id);

        public List<CouponUser> BGetCouponUserListWithActiveCouponListByUserId(string userId) => _couponUserDal.GetCouponUserListWithActiveCouponListWithUserId(userId);

        public List<CouponUser> BGetCouponUserListWithPassiveCouponListByUserId(string userId) => _couponUserDal.GetCouponUserListWithPassiveCouponListWithUserId(userId);
        public List<CouponUser> BGetCouponUserListWithUserListByCouponId(int id) => _couponUserDal.GetCouponUserListWithUserListByCouponId(id);

        public void BUpdate(CouponUser entity) => _couponUserDal.Update(entity);

        public CouponUser BGetCodeAvailable(string code, string userId) => _couponUserDal.GetCodeAvailable(code, userId);

        public Task BUpdateCouponUser(string code, string userId) => _couponUserDal.UpdateCouponUser(code, userId);
    }
}
