using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {

        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SignalRContext();
            var values = context.Notifications.Where(x => x.Status == false);
            return values.ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            var values = context.Notifications.Where(x => x.Status == false).Count();
            return values;
        }
    }
}
