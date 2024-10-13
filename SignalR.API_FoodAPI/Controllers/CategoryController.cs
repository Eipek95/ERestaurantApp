using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.CategoryDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.BGetAll();
            return Ok(values);
        }

        [HttpGet("GetAllCategoriesWithProducts")]
        public async Task<IActionResult> GetAllCategoriesWithProducts()
        {
            var values = await _categoryService.BGetAllCategoriesWithProductsAsync();
            return Ok(values);
        }
        [HttpGet("StatisticsGetCategoriesWithProductCountAsync")]
        public async Task<IActionResult> GetCategoriesWithProductCount()
        {
            var values = await _categoryService.BGetCategoriesWithProductCountAsync();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto create)
        {
            Category category = new Category()
            {
                Name = create.Name,
                Status = create.Status,
            };
            _categoryService.BAdd(category);
            return Ok("Kategori Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto update)
        {
            Category category = new Category()
            {
                Id = update.Id,
                Name = update.Name,
                Status = update.Status,
            };
            _categoryService.BUpdate(category);
            return Ok("Kategori Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.BGetById(id);
            _categoryService.BDelete(value);
            return Ok("Kategori Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = _categoryService.BGetById(id);
            return Ok(values);
        }

        [HttpGet("CategoryCount")]
        public IActionResult GetCategoryCount() => Ok(_categoryService.BGetCategoryCount());

        [HttpGet("ActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount() => Ok(_categoryService.BGetActiveCategoryCount());

        [HttpGet("PassiveCategoryCount")]
        public IActionResult GetPassiveCategoryCount() => Ok(_categoryService.BGetPassiveCategoryCount());
    }
}
