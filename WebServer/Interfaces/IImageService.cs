using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Interfaces
{
    public interface IImageService
    {
        Task<List<Image>> UploadImages(List<IFormFile> file, Guid parentId);
        List<byte[]> GetImagesByItemId(Guid itemId);
    }
}
