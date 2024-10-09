using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void BAdd(Notification entity) => _notificationDal.Add(entity);

        public void BDelete(Notification entity) => _notificationDal.Delete(entity);

        public List<Notification> BGetAll() => _notificationDal.GetAll();

        public List<Notification> BGetAllNotificationByFalse() => _notificationDal.GetAllNotificationByFalse();

        public Notification BGetById(int id) => _notificationDal.GetById(id);

        public int BNotificationCountByStatusFalse() => _notificationDal.NotificationCountByStatusFalse();

        public void BUpdate(Notification entity) => _notificationDal.Update(entity);
    }
}
