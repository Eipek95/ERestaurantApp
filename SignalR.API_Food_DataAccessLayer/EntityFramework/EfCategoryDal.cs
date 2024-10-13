using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int GetActiveCategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(x => x.Status == true).Count();
        }

        public async Task<List<Category>> GetAllCategoriesWithProductsAsync()
        {
            using var context = new SignalRContext();
            var categories = await context.Categories.Include(x => x.Products).ToListAsync();
            return categories;
        }

        public int GetCategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count();
        }

        public int GetPassiveCategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
