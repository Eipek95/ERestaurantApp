using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void BAdd(Category entity)
		{
			_categoryDal.Add(entity);
		}

		public void BDelete(Category entity)
		{
			_categoryDal.Delete(entity);
		}

		public int BGetActiveCategoryCount() => _categoryDal.GetActiveCategoryCount();
		public List<Category> BGetAll() => _categoryDal.GetAll();

		public Category BGetById(int id) => _categoryDal.GetById(id);

		public int BGetCategoryCount() => _categoryDal.GetCategoryCount();

		public int BGetPassiveCategoryCount() => _categoryDal.GetPassiveCategoryCount();

		public void BUpdate(Category entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
