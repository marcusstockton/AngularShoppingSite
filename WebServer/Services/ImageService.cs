using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebServer.Data;
using WebServer.Interfaces;

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

        public async Task<int> UploadImages(List<IFormFile> files, Guid parentId)
        {
            return await WriteFile(files, parentId);
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="files"></param>
        /// <param name="parentId"></param>
        public async Task WriteFile(List<IFormFile> files, Guid parentId)
        {
            try
            {
                foreach(var file in files)
                {
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    var uploads = Path.Combine(_appEnvironment.ContentRootPath, "Uploads\\img");
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        await _context.Images.AddAsync(new Models.Image
                        {
                            Path = Path.Combine(uploads, fileName),
                            Type = extension,
                            CreatedById = _userService.GetLoggedInUserId(),
                            CreatedDate = DateTime.Now,
                            ParentId = parentId
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
