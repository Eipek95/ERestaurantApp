using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void BAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void BDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public List<Discount> BGetAll()
        {
            return _discountDal.GetAll();
        }

        public Discount BGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public void BUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
