using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
	public interface IMenuTableService : IGenericService<MenuTable>
	{
		int BMenuTableCount();
	}
}
