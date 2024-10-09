using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void BAdd(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void BDelete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public List<SocialMedia> BGetAll()
        {
            return _socialMediaDal.GetAll();
        }

        public SocialMedia BGetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }

        public void BUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
