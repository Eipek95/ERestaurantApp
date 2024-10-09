using Microsoft.EntityFrameworkCore;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}



		public int GetProductCountWithCategoryNameForDrink()
		{
			var context = new SignalRContext();
			var values = context.Products.Where(
				x => x.Category.Name == (context.Categories.Where(y => y.Id == 5).Select(x => x.Name).FirstOrDefault())).Count();
			return values;
		}

		public int GetProductCountWithCategoryNameForHamburger()
		{
			var context = new SignalRContext();
			var values = context.Products.Where(
				x => x.Category.Name == (context.Categories.Where(y => y.Id == 1).Select(x => x.Name).FirstOrDefault())).Count();
			return values;
		}

		public List<Product> GetProductsWithCategories()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).ToList();
			return values;
		}

		public int ProductCount()
		{
			var context = new SignalRContext();
			var values = context.Products.Count();
			return values;
		}

		public string ProductNameByMaxPrice()
		{
			var context = new SignalRContext();
			var values = context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.Name).FirstOrDefault();
			return values!;
		}

		public string ProductNameByMinPrice()
		{
			var context = new SignalRContext();
			var values = context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.Name).FirstOrDefault();
			return values!;
		}

		public decimal ProductPriceAvg()
		{
			var context = new SignalRContext();
			var values = context.Products.Average(x => x.Price);
			return values;
		}

		public decimal ProductAvgPriceByHamburger()
		{
			var context = new SignalRContext();
			var values = context.Products.Where(
				x => x.Category.Id == (context.Categories.Where(y => y.Name == "Hamburger").Select(x => x.Id).FirstOrDefault())).Average(z => z.Price);
			return values;
		}
	}
}
