using AutoMapper;
using SignalR.API_Food_DtoLayer.SliderDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Mapping
{
	public class SliderMapping : Profile
	{
		public SliderMapping()
		{
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
			CreateMap<Slider, CreateSliderDto>().ReverseMap();
			CreateMap<Slider, GetSliderDto>().ReverseMap();
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();
		}
	}
}
