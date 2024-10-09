using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DtoLayer.CouponUserDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponUserController : ControllerBase
    {
        private readonly ICouponUserService _couponUserService;
        private readonly IMapper _mapper;

        public CouponUserController(ICouponUserService couponUserService, IMapper mapper)
        {
            _couponUserService = couponUserService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CouponUserList()
        {
            var values = _mapper.Map<List<ResultCouponUserDto>>(_couponUserService.BGetAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCouponUser(CreateCouponUserDto createCouponUserDto)
        {
            var values = _mapper.Map<CouponUser>(createCouponUserDto);
            _couponUserService.BAdd(values);
            return Ok("Başarıyla Kaydedildi");
        }

        [HttpPost("CreateListCouponUser")]
        public IActionResult CreateListCouponUser(List<CreateCouponUserDto> createCouponUserDto)
        {
            var values = _mapper.Map<List<CouponUser>>(createCouponUserDto);
            _couponUserService.BAddList(values);
            return Ok("Başarıyla Kaydedildi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCouponUser(int id)
        {
            var values = _couponUserService.BGetById(id);
            _couponUserService.BDelete(values);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCouponUser(UpdateCouponUserDto updateCouponUserDto)
        {
            var values = _mapper.Map<CouponUser>(updateCouponUserDto);
            _couponUserService.BUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }

        [HttpGet("GetCouponUserList/{id}")]
        public IActionResult GetCouponUserList(int id)
        {
            var values = _mapper.Map<List<ResultCouponUserDto>>(_couponUserService.BGetCouponUserList(id));
            return Ok(values);
        }

        [HttpGet("GetCouponUserListWithUserByCouponId/{id}")]
        public IActionResult GetCouponUserListWithUserByCouponId(int id)
        {
            var values = _mapper.Map<List<ResultCouponUserListWithUserDto>>(_couponUserService.BGetCouponUserListWithUserListByCouponId(id));
            return Ok(values);
        }


        [HttpGet("GetCouponUserListWithActiveCouponListByUserId/{userId}")]
        public IActionResult GetCouponUserListWithActiveCouponListByUserId(string userId)
        {
            var values = _mapper.Map<List<ResultCouponUserListWithActiveCouponListDto>>(_couponUserService.BGetCouponUserListWithActiveCouponListByUserId(userId));
            return Ok(values);
        }

        [HttpGet("GetCouponUserListWithPassiveCouponListByUserId/{userId}")]
        public IActionResult GetCouponUserListWithPassiveCouponListByUserId(string userId)
        {
            var values = _mapper.Map<List<ResultCouponUserListWithActiveCouponListDto>>(_couponUserService.BGetCouponUserListWithPassiveCouponListByUserId(userId));
            return Ok(values);
        }

        [HttpGet("GetCodeAvailable")]
        public IActionResult BGetCodeAvailable(string code, string userId)
        {
            var values = _mapper.Map<ResultCouponUserListWithActiveCouponListDto>(_couponUserService.BGetCodeAvailable(code, userId));
            return Ok(values);
        }
    }
}
