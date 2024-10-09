using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
    public interface ICouponUserService : IGenericService<CouponUser>
    {
        public void BAddList(List<CouponUser> couponUsers);
        public List<CouponUser> BGetCouponUserList(int id);
        public List<CouponUser> BGetCouponUserListWithUserListByCouponId(int id);
        public List<CouponUser> BGetCouponUserListWithActiveCouponListByUserId(string userId);
        public List<CouponUser> BGetCouponUserListWithPassiveCouponListByUserId(string userId);
        public CouponUser BGetCodeAvailable(string code, string userId);
    }
}
