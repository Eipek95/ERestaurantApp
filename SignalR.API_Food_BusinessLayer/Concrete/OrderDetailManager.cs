using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void BAdd(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void BDelete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> BGetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetail BGetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetail>> BGetOrderDetailByOrderId(int orderId) => await _orderDetailDal.GetOrderDetailByOrderId(orderId);

        public void BUpdate(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
