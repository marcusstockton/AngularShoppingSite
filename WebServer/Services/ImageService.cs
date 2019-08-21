using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebServer.Data;
using WebServer.Interfaces;
using WebServer.Models;

namespace WebServer.Services
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IHostingEnvironment _appEnvironment;

        public ImageService(ApplicationDbContext context, IUserService userService, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _userService = userService;
            _appEnvironment = appEnvironment;
        }

        public async Task<List<Image>> UploadImages(List<IFormFile> files)
        {
            return await WriteFile(files);
        }
        
        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="files"></param>
        private async Task<List<Image>> WriteFile(List<IFormFile> files)
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
                var imageFolder = "Uploads\\img";
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
