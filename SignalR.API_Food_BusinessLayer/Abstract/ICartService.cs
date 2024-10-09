using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
    public interface ICartService : IGenericService<Cart>
    {
        Task BInitializeCart(string userId);
        Task<Cart> BGetBasket(string userId);
        Task BSaveBasket(Cart basketTotalDto);
        //Task BDeleteBasket(string userId);
        Task BDeleteBasket(int cartId, int productId);
    }
}
