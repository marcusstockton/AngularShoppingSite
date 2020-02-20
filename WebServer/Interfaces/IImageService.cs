using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Interfaces
{
    public interface IImageService
    {
        Task<List<Image>> UploadImages(List<IFormFile> file);
        Task<List<byte[]>> GetImagesAsByteArrayForItemId(Guid itemId);
        Task<List<KeyValuePair<string, string>>> GetImagesForItemId(Guid itemId);
    }
}
