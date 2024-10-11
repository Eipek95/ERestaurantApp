using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
    public interface ICouponUserDal : IGenericDal<CouponUser>
    {
        public void AddList(List<CouponUser> couponUsers);
        public List<CouponUser> GetCouponUserList(int id);
        public List<CouponUser> GetCouponUserListWithUserListByCouponId(int id);
        public List<CouponUser> GetCouponUserListWithActiveCouponListWithUserId(string userId);
        public List<CouponUser> GetCouponUserListWithPassiveCouponListWithUserId(string userId);
        public CouponUser GetCodeAvailable(string code, string userId);
        public Task UpdateCouponUser(string code, string userId);
    }
}
