using System;
using System.Collections.Generic;
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
            CreateMap<ItemEdit, Item>().ReverseMap()
                .ForMember(d=>d.ItemCategoryId, opt => opt.MapFrom(src=> src.ItemCategory.Id))
                .ForMember(d => d.ItemConditionId, opt => opt.MapFrom(src => src.ItemCondition.Id))
                .ForMember(d => d.DeliveryOptionId, opt => opt.MapFrom(src => src.DeliveryOption.Id));

            CreateMap<Item, ItemDetails>()
                .ForMember(d=> d.CreatedBy, opt=>opt.MapFrom(src=>src.CreatedBy))
                .ForMember(d => d.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember( d => d.UpdatedBy, opt => opt.MapFrom( src => string.IsNullOrEmpty( src.UpdatedBy.FirstName + " " + src.UpdatedBy.LastName ) ? src.UpdatedBy.Email : src.UpdatedBy.FirstName + " " + src.UpdatedBy.LastName ?? "" ) )
                .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src=>string.IsNullOrEmpty(src.CreatedBy.FirstName + " " + src.CreatedBy.LastName) ? src.CreatedBy.Email : src.CreatedBy.FirstName + " " + src.CreatedBy.LastName ) )
                .ForMember(d => d.ItemCategoryDto, opt => opt.MapFrom(src => new KeyValuePair<Guid, string>(src.ItemCategory.Id, src.ItemCategory.Description)))
                .ForMember(d => d.ItemConditionDto, opt => opt.MapFrom(src => new KeyValuePair<Guid, string>(src.ItemCondition.Id, src.ItemCondition.Description)))
                .ForMember(d => d.DeliveryOptionDto, opt => opt.MapFrom(src => new KeyValuePair<Guid, string>(src.DeliveryOption.Id, src.DeliveryOption.Description)));
;
        }
    }
}
