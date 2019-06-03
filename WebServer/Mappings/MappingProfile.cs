using AutoMapper;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

namespace WebServer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemCreate, Item>().ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images)).ReverseMap();
            CreateMap<ItemEdit, Item>().ReverseMap();
        }
    }
}
