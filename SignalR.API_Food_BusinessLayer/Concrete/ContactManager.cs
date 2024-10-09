using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void BAdd(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void BDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact> BGetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact BGetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public void BUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
