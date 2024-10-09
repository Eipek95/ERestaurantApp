using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void BAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void BDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public List<About> BGetAll()
        {
            return _aboutDal.GetAll();
        }

        public About BGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void BUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
