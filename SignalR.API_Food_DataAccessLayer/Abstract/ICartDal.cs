using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
    public interface ICartDal : IGenericDal<Cart>
    {
        Task InitializeCart(string userId);
        Task<Cart> GetBasket(string userId);
        Task SaveBasket(Cart basketTotalDto);
        //Task DeleteBasket(string userId);
        Task DeleteBasket(int cartId, int productId);
    }
}
