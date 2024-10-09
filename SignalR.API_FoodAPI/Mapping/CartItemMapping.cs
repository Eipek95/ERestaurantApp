using AutoMapper;
using SignalR.API_Food_DtoLayer.CartItemDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Mapping
{
    public class CartItemMapping : Profile
    {
        public CartItemMapping()
        {
            CreateMap<CartItem, ResultCartItemDto>().ReverseMap();
        }
    }
}
