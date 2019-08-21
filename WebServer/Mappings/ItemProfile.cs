using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

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
                .ForMember(d => d.Images, opt => opt.MapFrom(src => src.Images));
        }
    }
}
