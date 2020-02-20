using AutoMapper;
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
