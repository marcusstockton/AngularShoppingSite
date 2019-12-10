using AutoMapper;
using WebServer.Models;
using WebServer.Models.DTOs.Images;

namespace WebServer.Mappings
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            AllowNullCollections = true;

            CreateMap<ImageDetails, Image>().ReverseMap();
        }
    }
}