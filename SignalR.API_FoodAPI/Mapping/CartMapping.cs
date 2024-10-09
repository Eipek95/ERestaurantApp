using AutoMapper;
using SignalR.API_Food_DtoLayer.CartDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Mapping
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<Cart, ResultCartDto>().ReverseMap();
            CreateMap<Cart, CreateCartDto>().ReverseMap();
            CreateMap<Cart, UpdateCartDto>().ReverseMap();
        }
    }
}
