using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.MenuTableDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;
		public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MenuTableCount() => Ok(_menuTableService.BMenuTableCount());

		[HttpGet("MenuTableList")]
		public IActionResult MenuTableList()
		{
			var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.BGetAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			createMenuTableDto.Status = false;
			var values = _mapper.Map<MenuTable>(createMenuTableDto);
			_menuTableService.BAdd(values);
			return Ok("Başarıyla Kaydedildi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var values = _menuTableService.BGetById(id);
			_menuTableService.BDelete(values);
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var values = _mapper.Map<MenuTable>(updateMenuTableDto);
			_menuTableService.BUpdate(values);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var values = _mapper.Map<ResultMenuTableDto>(_menuTableService.BGetById(id));
			return Ok(values);
		}
	}
}
