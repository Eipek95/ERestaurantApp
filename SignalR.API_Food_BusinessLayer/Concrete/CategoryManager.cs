using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DtoLayer.CategoryDto;
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

        public Task<List<Category>> BGetAllCategoriesWithProductsAsync() => _categoryDal.GetAllCategoriesWithProductsAsync();

        public Category BGetById(int id) => _categoryDal.GetById(id);

        public async Task<List<GetCategoryProductStatistics1>> BGetCategoriesWithProductCountAsync()
        {
            var result = await BGetAllCategoriesWithProductsAsync();
            var categoryProductCounts = result.Where(x => x.Status)
                .Select(x => new GetCategoryProductStatistics1
                {
                    CategoryId = x.Id,
                    CategoryName = x.Name,
                    ProductCount = x.Products.Count(p => p.Status)
                }).ToList();

            return categoryProductCounts;
        }

        public int BGetCategoryCount() => _categoryDal.GetCategoryCount();

        public int BGetPassiveCategoryCount() => _categoryDal.GetPassiveCategoryCount();

        public void BUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
