using AutoMapper;
using SignalR.API_Food_DtoLayer.CouponUserDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Mapping
{
    public class CouponUserMapping : Profile
    {
        public CouponUserMapping()
        {
            CreateMap<CouponUser, ResultCouponUserDto>().ReverseMap();
            CreateMap<CouponUser, CreateCouponUserDto>().ReverseMap();
            CreateMap<CouponUser, UpdateCouponUserDto>().ReverseMap();
            CreateMap<CouponUser, ResultCouponUserListWithUserDto>().ReverseMap();
            CreateMap<CouponUser, ResultCouponUserListWithActiveCouponListDto>().ReverseMap();
        }
    }
}
