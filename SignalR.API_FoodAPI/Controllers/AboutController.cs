using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.AboutDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}
		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _aboutService.BGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto create)
		{
			About about = new About()
			{
				Description = create.Description,
				ImageUrl = create.ImageUrl,
				Title = create.Title,
			};
			_aboutService.BAdd(about);
			return Ok("Hakkımda Kısmı Başarılı Bir Şekilde  Eklendi");
		}

		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutDto update)
		{
			About about = new About()
			{
				Id = update.Id,
				Description = update.Description,
				ImageUrl = update.ImageUrl,
				Title = update.Title,
			};
			_aboutService.BUpdate(about);
			return Ok("Hakkımda Kısmı Başarılı Bir Şekilde  Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteAbout(int id)
		{
			var value = _aboutService.BGetById(id);
			_aboutService.BDelete(value);
			return Ok("Hakkımda Alanı Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var values = _aboutService.BGetById(id);
			return Ok(values);
		}
	}
}
