using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models.DTOs.Users;

namespace WebServer.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDetails, ApplicationUser>().ReverseMap();
        }
    }
}
