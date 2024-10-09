using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.ProductDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.BGetAll());
			return Ok(values);
		}

		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.BGetProductsWithCategories());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			var values = _mapper.Map<Product>(createProductDto);
			_productService.BAdd(values);
			return Ok("Başarıyla Kaydedildi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var values = _productService.BGetById(id);
			_productService.BDelete(values);
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var values = _mapper.Map<Product>(updateProductDto);
			_productService.BUpdate(values);
			return Ok("Başarıyla Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var values = _productService.BGetById(id);
			return Ok(values);
		}

		[HttpGet("ProductCount")]
		public IActionResult GetProductCount() => Ok(_productService.BProductCount());

		[HttpGet("GetProductCountWithCategoryNameForHamburger")]
		public IActionResult GetProductCountWithCategoryNameForHamburger() => Ok(_productService.BGetProductCountWithCategoryNameForHamburger());

		[HttpGet("GetProductCountWithCategoryNameForDrink")]
		public IActionResult GetProductCountWithCategoryNameForDrink() => Ok(_productService.BGetProductCountWithCategoryNameForDrink());
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg() => Ok(_productService.BProductPriceAvg());
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice() => Ok(_productService.BProductNameByMaxPrice());
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice() => Ok(_productService.BProductNameByMinPrice());
		[HttpGet("ProductAvgPriceByHamburger")]
		public IActionResult ProductAvgPriceByHamburger() => Ok(_productService.BProductAvgPriceByHamburger());
	}
}
