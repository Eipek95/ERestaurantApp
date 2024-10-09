using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.SliderDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly ISliderService _SliderService;
		private readonly IMapper _mapper;

		public SliderController(ISliderService sliderService, IMapper mapper)
		{
			_SliderService = sliderService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult SliderList() => Ok(_mapper.Map<List<ResultSliderDto>>(_SliderService.BGetAll()));
		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			var values = _mapper.Map<Slider>(createSliderDto);
			_SliderService.BAdd(values);
			return Ok("Başarıyla Kaydedildi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSlider(int id)
		{
			var values = _SliderService.BGetById(id);
			_SliderService.BDelete(values);
			return Ok("Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetSlider(int id) => Ok(_SliderService.BGetById(id));
		[HttpPut]
		public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
		{
			var values = _mapper.Map<Slider>(updateSliderDto);
			_SliderService.BUpdate(values);
			return Ok("Başarıyla Güncellendi");
		}
	}
}
