using AutoMapper;
using SignalR.API_Food_DtoLayer.CategoryDto;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_FoodAPI.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
