using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfCouponUserDal : GenericRepository<CouponUser>, ICouponUserDal
    {
        public EfCouponUserDal(SignalRContext context) : base(context)
        {
        }

        public void AddList(List<CouponUser> couponUsers)
        {
            using var context = new SignalRContext();
            context.CouponUsers.AddRange(couponUsers);
            context.SaveChanges();
        }

        public CouponUser GetCodeAvailable(string code, string userId)
        {
            using var context = new SignalRContext();
            var couponUser = context.CouponUsers.Where(x => x.AppUserId == userId).
                Include(y => y.Coupon).
                Where(x => x.Coupon.Code.ToLower() == code.ToLower() && x.Status == true).
                FirstOrDefault();
            return couponUser;
        }

        public List<CouponUser> GetCouponUserList(int id)
        {
            using var context = new SignalRContext();
            var list = context.CouponUsers.Where(x => x.CouponId == id);
            return list.ToList();
        }

        public List<CouponUser> GetCouponUserListWithActiveCouponListWithUserId(string userId)
        {
            using var context = new SignalRContext();
            var list = context.CouponUsers.Include(x => x.Coupon).Where(x => x.AppUserId == userId && x.Status == true);
            return list.ToList();
        }

        public List<CouponUser> GetCouponUserListWithPassiveCouponListWithUserId(string userId)
        {
            using var context = new SignalRContext();
            var list = context.CouponUsers.Include(x => x.Coupon).Where(x => x.AppUserId == userId && x.Status == false);
            return list.ToList();
        }

        public List<CouponUser> GetCouponUserListWithUserListByCouponId(int id)
        {
            using var context = new SignalRContext();
            var list = context.CouponUsers.Include(x => x.AppUser).Where(x => x.CouponId == id);
            return list.ToList();
        }

        public async Task UpdateCouponUser(string code, string userId)
        {
            using var context = new SignalRContext();
            var couponUser = context.CouponUsers.Where(x => x.AppUserId == userId).Include(y => y.Coupon).
                Where(x => x.Coupon.Code.ToLower() == code.ToLower() && x.Status == true).FirstOrDefault();
            couponUser.Status = false;
            context.CouponUsers.Update(couponUser);
            await context.SaveChangesAsync();
        }
    }
}
