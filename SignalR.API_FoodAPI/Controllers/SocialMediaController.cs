using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.SocialMediaDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList() => Ok(_mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.BGetAll()));
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.BAdd(values);
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.BGetById(id);
            _socialMediaService.BDelete(values);
            return Ok("Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id) => Ok(_socialMediaService.BGetById(id));
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.BUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
