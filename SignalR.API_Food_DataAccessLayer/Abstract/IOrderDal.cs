using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int TotalOrderCount();
        int ActiveOrderCount();
        int PassiveOrderCount();
        int SellingProductCount();
        decimal LastOrderPrice();
        decimal TodayTotalPrice();
        string TopSellingProduct();
        Task SaveOrder(Order order);
        Task<List<Order>> GetOrderByOrderStatus(string orderStatus);
        Task<List<Order>> GetOrderByUserId(string userId);
    }
}
