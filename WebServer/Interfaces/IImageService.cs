using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Interfaces
{
    public interface IImageService
    {
        Task<List<Image>> UploadImagesForItem(Guid itemId, List<IFormFile> files);
        Task<List<byte[]>> GetImagesAsByteArrayForItemId(Guid itemId);
        Task<List<KeyValuePair<string, string>>> GetImagesForItemId(Guid itemId);
        Task<Image> UploadAvatar(string userid, IFormFile avatar);
    }
}
