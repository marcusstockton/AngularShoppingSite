using AutoMapper;
using WebServer.Models;
using WebServer.Models.DTOs.Reviews;
using System;

namespace WebServer.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewDetails, Review>().ForMember(dest => dest.UpdatedBy, opt => opt.Condition(source => source.UpdatedBy.Id != Guid.Empty)).ReverseMap();
            CreateMap<ReviewEdit, Review>().ReverseMap();
            CreateMap<ReviewCreate, Review>().ReverseMap();
        }
    }
}
