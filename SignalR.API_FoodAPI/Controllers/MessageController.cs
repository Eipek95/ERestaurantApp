using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.MessageDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;

		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _mapper.Map<List<ResultMessageDto>>(_messageService.BGetAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.Status = false;
			var values = _mapper.Map<Message>(createMessageDto);
			_messageService.BAdd(values);
			return Ok("Başarıyla Kaydedildi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var values = _messageService.BGetById(id);
			_messageService.BDelete(values);
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var values = _mapper.Map<Message>(updateMessageDto);
			_messageService.BUpdate(values);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var values = _mapper.Map<ResultMessageDto>(_messageService.BGetById(id));
			return Ok(values);
		}
	}
}
