using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.NotificationDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            var result = _notificationService.BGetAll();
            return Ok(result);
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var result = _notificationService.BNotificationCountByStatusFalse();
            return Ok(result);
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            var result = _notificationService.BGetAllNotificationByFalse();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var values = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.BAdd(values);
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var values = _notificationService.BGetById(id);
            _notificationService.BDelete(values);
            return Ok("Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var values = _mapper.Map<ResultNotificationDto>(_notificationService.BGetById(id));
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var values = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.BUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
