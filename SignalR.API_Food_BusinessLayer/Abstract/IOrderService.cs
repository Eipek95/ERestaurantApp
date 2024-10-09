using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
	public interface IOrderService : IGenericService<Order>
	{
		int BTotalOrderCount();
		int BActiveOrderCount();
		int BPassiveOrderCount();

		decimal BLastOrderPrice();
		decimal BTodayTotalPrice();
	}
}
