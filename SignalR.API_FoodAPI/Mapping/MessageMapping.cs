using AutoMapper;
using SignalR.API_Food_DtoLayer.MessageDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Mapping
{
	public class MessageMapping : Profile
	{
		public MessageMapping()
		{
			CreateMap<Message, ResultMessageDto>().ReverseMap();
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
		}
	}
}
