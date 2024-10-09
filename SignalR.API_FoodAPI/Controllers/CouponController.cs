using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.CouponDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IMapper _mapper;

        public CouponController(ICouponService couponService, IMapper mapper)
        {
            _couponService = couponService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CouponList()
        {
            var values = _mapper.Map<List<ResultCouponDto>>(_couponService.BGetAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCoupon(CreateCouponDto createCouponDto)
        {
            var values = _mapper.Map<Coupon>(createCouponDto);
            _couponService.BAdd(values);
            return Ok("Başarıyla Kaydedildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCoupon(int id)
        {
            var values = _couponService.BGetById(id);
            _couponService.BDelete(values);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            var values = _mapper.Map<Coupon>(updateCouponDto);
            _couponService.BUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCoupon(int id)
        {
            var values = _mapper.Map<ResultCouponDto>(_couponService.BGetById(id));
            return Ok(values);
        }
    }
}
