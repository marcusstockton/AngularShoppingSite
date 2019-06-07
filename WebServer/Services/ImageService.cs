using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
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

        public async Task<List<Image>> UploadImages(List<IFormFile> files, Guid parentId)
        {
            return await WriteFile(files, parentId);
        }

        public async Task<List<Uri>> GetFiles(List<Image> files)
        {
            var images = new List<Uri>();
            string webRootPath = _appEnvironment.WebRootPath;
            string contentRootPath = _appEnvironment.ContentRootPath;

            foreach (var image in files)
            {
                images.Add(new Uri(image.Path));
            }

            return images;
        }


        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="files"></param>
        /// <param name="parentId"></param>
        private async Task<List<Image>> WriteFile(List<IFormFile> files, Guid parentId)
        {
            try
            {
                var images = new List<Image>();
                foreach (var file in files)
                {
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    var uploads = Path.Combine(_appEnvironment.ContentRootPath, "Uploads\\img");
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        var img = new Image
                        {
                            Path = Path.Combine(uploads, fileName),
                            Type = extension,
                            CreatedById = _userService.GetLoggedInUserId(),
                            CreatedDate = DateTime.Now,
                        };
                        images.Add(img);
                    }
                }
                return images;
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
