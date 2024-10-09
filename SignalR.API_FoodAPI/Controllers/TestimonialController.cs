using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.TestimonialDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult TestimonialList() => Ok(_mapper.Map<List<ResultTestimonialDto>>(_testimonialService.BGetAll()));
		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			var values = _mapper.Map<Testimonial>(createTestimonialDto);
			_testimonialService.BAdd(values);
			return Ok("Başarıyla Kaydedildi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var values = _testimonialService.BGetById(id);
			_testimonialService.BDelete(values);
			return Ok("Başarıyla Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetTestimonia(int id) => Ok(_testimonialService.BGetById(id));
		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			var values = _mapper.Map<Testimonial>(updateTestimonialDto);
			_testimonialService.BUpdate(values);
			return Ok("Başarıyla Güncellendi");
		}
	}
}
