using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }



        public void BAdd(Cart entity) => _cartDal.Add(entity);

        public void BDelete(Cart entity)
        {
            throw new NotImplementedException();
        }


        public Task BDeleteBasket(int cartId, int productId) => _cartDal.DeleteBasket(cartId, productId);

        public List<Cart> BGetAll() => _cartDal.GetAll();

        public Task<Cart> BGetBasket(string userId) => _cartDal.GetBasket(userId);

        public Cart BGetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task BInitializeCart(string userId) => _cartDal.InitializeCart(userId);

        public Task BSaveBasket(Cart basketTotalDto) => _cartDal.SaveBasket(basketTotalDto);

        public void BUpdate(Cart entity)
        {
            throw new NotImplementedException();
        }


    }
}
