using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void BAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void BDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> BGetAll()
        {
            throw new NotImplementedException();
        }


        public Basket BGetById(int id) => _basketDal.GetById(id);

        public void BUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
