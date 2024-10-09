using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfSliderDal : GenericRepository<Slider>, ISliderDal
    {
        public EfSliderDal(SignalRContext context) : base(context)
        {
        }
    }
}
