using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Interfaces
{
    public interface IImageService
    {
        Task<int> UploadImages(List<IFormFile> file, Guid parentId);
    }
}
