using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Models.DTOs.Reviews;

namespace WebServer.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewDetails, Review>().ReverseMap();
        }
    }
}
