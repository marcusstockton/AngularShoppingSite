using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

namespace WebServer.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemCreate, Item>().ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images)).ReverseMap();
            CreateMap<ItemEdit, Item>().ReverseMap();
            CreateMap<ItemDetails, Item>().ReverseMap();
        }
    }
}
