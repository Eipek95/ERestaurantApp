using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int TotalOrderCount();
        int ActiveOrderCount();
        int PassiveOrderCount();
        decimal LastOrderPrice();
        decimal TodayTotalPrice();
        Task SaveOrder(Order order);
    }
}
