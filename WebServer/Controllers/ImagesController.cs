using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServer.Data;
using WebServer.Interfaces;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/Images
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        //{
        //    return await _context.Images.ToListAsync();
        //}

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PhysicalFileResult>>> GetImagesForItemId(Guid id)
        {
            var images = await _imageService.GetImagesForItemId( id );
            var result = new List<PhysicalFileResult>();
            if (images == null)
            {
                return NotFound();
            }
            foreach (var item in images)
            {
                result.Add( PhysicalFile( item.Key, $"application/{ item.Value.Split( "." ).Last()}" ) );
            }
            return result;
        }

        //// PUT: api/Images/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutImage(Guid id, Image image)
        //{
        //    if (id != image.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(image).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ImageExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Images
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost, Route("CreateImagesForItem/{itemId}")]
        [Authorize]
        public async Task<ActionResult<List<Image>>> CreateImagesForItem(Guid itemId, List<IFormFile> images)
        {
            return await _imageService.UploadImagesForItem(itemId, images);
        }

        //// DELETE: api/Images/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Image>> DeleteImage(Guid id)
        //{
        //    var image = await _context.Images.FindAsync(id);
        //    if (image == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Images.Remove(image);
        //    await _context.SaveChangesAsync();

        //    return image;
        //}

        //private bool ImageExists(Guid id)
        //{
        //    return _context.Images.Any(e => e.Id == id);
        //}
    }
}
