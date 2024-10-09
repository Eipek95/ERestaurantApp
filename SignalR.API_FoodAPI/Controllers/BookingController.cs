using Microsoft.AspNetCore.Mvc;
using SignalR.API_Common;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.BookingDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.BGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto create)
        {
            Booking booking = new Booking()
            {
                Date = create.Date,
                Mail = create.Mail,
                Name = create.Name,
                PersonCount = create.PersonCount,
                Phone = create.Phone,
                Status = ReservationStatus.Alındı.ToString(),
            };
            _bookingService.BAdd(booking);
            return Ok("Rezervasyon Yapıldı");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto update)
        {
            Booking booking = new Booking()
            {
                Id = update.Id,
                Date = update.Date,
                Mail = update.Mail,
                Name = update.Name,
                PersonCount = update.PersonCount,
                Phone = update.Phone,
                Status = update.Status.ToString(),
            };
            _bookingService.BUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.BGetById(id);
            _bookingService.BDelete(value);
            return Ok("Rezervasyon Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.BGetById(id);
            return Ok(values);
        }
    }
}
