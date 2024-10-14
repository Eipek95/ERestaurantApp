using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
    public interface IOrderDetailDal : IGenericDal<OrderDetail>
    {
        Task<List<OrderDetail>> GetOrderDetailByOrderId(int orderId);
    }
}
