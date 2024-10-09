using AutoMapper;
using SignalR.API_Food_DtoLayer.MenuTableDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
        }
    }
}
