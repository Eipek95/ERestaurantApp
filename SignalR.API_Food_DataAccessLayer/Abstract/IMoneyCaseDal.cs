using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
	public interface IMoneyCaseDal : IGenericDal<MoneyCase>
	{
		decimal TotalMoneyCaseAmount();
	}
}
