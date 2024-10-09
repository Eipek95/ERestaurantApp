using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
	public interface ICategoryService : IGenericService<Category>
	{
		public int BGetCategoryCount();
		public int BGetActiveCategoryCount();
		public int BGetPassiveCategoryCount();
	}
}
