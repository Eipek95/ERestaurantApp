using SignalR.API_Food_DtoLayer.CategoryDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        int BGetCategoryCount();
        int BGetActiveCategoryCount();
        int BGetPassiveCategoryCount();
        Task<List<Category>> BGetAllCategoriesWithProductsAsync();
        Task<List<GetCategoryProductStatistics1>> BGetCategoriesWithProductCountAsync();
    }
}
