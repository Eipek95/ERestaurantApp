using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
	public interface ICategoryDal : IGenericDal<Category>
	{
		public int GetCategoryCount();
		public int GetActiveCategoryCount();
		public int GetPassiveCategoryCount();
	}
}
