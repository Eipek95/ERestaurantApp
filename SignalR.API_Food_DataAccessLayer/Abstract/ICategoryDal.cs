using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        int GetCategoryCount();
        int GetActiveCategoryCount();
        int GetPassiveCategoryCount();
        Task<List<Category>> GetAllCategoriesWithProductsAsync();
    }
}
