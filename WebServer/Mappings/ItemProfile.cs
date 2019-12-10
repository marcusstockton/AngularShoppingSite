using AutoMapper;
using WebServer.Models.DTOs.Items;
using WebServer.Models.Items;

namespace WebServer.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            AllowNullCollections = true;

            CreateMap<ItemCreate, Item>().ReverseMap();
            CreateMap<ItemEdit, Item>().ReverseMap();
            CreateMap<Item, ItemDetails>()
                .ForMember(d=> d.CreatedBy, opt=>opt.MapFrom(src=>src.CreatedBy))
                .ForMember(d => d.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(d => d.ItemCategory, opt => opt.MapFrom(src => src.ItemCategory));
        }
    }
}
