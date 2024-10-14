using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
    public interface IOrderDetailService : IGenericService<OrderDetail>
    {
        Task<List<OrderDetail>> BGetOrderDetailByOrderId(int orderId);
    }
}
