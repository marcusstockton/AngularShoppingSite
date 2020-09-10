using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebServer.Data;
using WebServer.Interfaces;
using WebServer.Models;

namespace WebServer.Services
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _appEnvironment;

        public ImageService(ApplicationDbContext context, IUserService userService, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _userService = userService;
            _appEnvironment = appEnvironment;
        }

        public async Task<List<Image>> UploadImagesForItem(Guid itemId, List<IFormFile> files)
        {
            return await WriteFile(itemId.ToString(), files);
        }

        public async Task<Image> UploadAvatar(string userid, IFormFile avatar)
        {
            var imageAsList = new List<IFormFile>();
            imageAsList.Add(avatar);

            var data = await WriteFile(userid, imageAsList, false);
            return data.First();
        }

        public async Task<List<byte[]>> GetImagesAsByteArrayForItemId(Guid itemId)
        {
            var images = _context.Images.Where( x => x.ItemId == itemId ).ToList();

            // Read the image into the result list:
            List<byte[]> imageBytes = new List<byte[]>();
            for (int i = 0; i < images.Count(); i++)
            {
                var filePath = Path.Combine( _appEnvironment.ContentRootPath, "Uploads\\img", images[i].FileName);
                byte[] bytes = await File.ReadAllBytesAsync( filePath );
                imageBytes.Add( bytes );
            }
            return imageBytes;
        }

        public async Task<List<KeyValuePair<string, string>>> GetImagesForItemId(Guid itemId)
        {
            return await _context.Images.Where( x => x.ItemId == itemId ).Select(x=> new KeyValuePair<string, string>( Path.Combine( _appEnvironment.ContentRootPath, "Uploads\\img", x.FileName ), x.Type )).ToListAsync();
        }
        
        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="files"></param>
        /// <param name="isItem"></param>
        private async Task<List<Image>> WriteFile(string parentId, List<IFormFile> files, bool isItem = true)
        {
            var reservedWords = new[]
            {
                "CON", "PRN", "AUX", "CLOCK$", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
                "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4",
                "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
            };
            
            try
            {
                var images = new List<Image>();
                var imageFolder = Path.Combine("Uploads", "img", isItem ? "items" : "avatars", parentId);
                if(!Directory.Exists(imageFolder)){
                    Directory.CreateDirectory(imageFolder);
                }
                foreach (var file in files)
                {
                    foreach (string x in reservedWords)
                    {
                        if (file.FileName.Contains(x))
                        {
                            file.FileName.Replace(x, "");
                        }
                    }

                    var invalids = Path.GetInvalidFileNameChars();
                    var fileName = String.Join("_", file.FileName.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    var uploads = Path.Combine(_appEnvironment.ContentRootPath, imageFolder);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        var img = new Image
                        {
                            Path = Path.Combine(imageFolder, fileName),
                            FileName = fileName,
                            Type = extension,
                            CreatedById = _userService.GetLoggedInUserId(),
                            CreatedDate = DateTime.Now,
                        };
                        images.Add(img);
                    }
                }
                return images;
            }
            catch(Exception)
            {
                throw;
            }

        }
    }
}
