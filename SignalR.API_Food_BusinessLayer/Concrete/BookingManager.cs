using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void BAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void BDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> BGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking BGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public void BUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
