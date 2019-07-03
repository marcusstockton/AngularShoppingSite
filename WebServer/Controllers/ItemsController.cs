using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Interfaces;
using WebServer.Models;
using WebServer.Models.DTOs.Items;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _service;
        private readonly IImageService _imageService;

        public ItemsController(IItemsService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        // GET api/values
        // curl https://localhost:5001/api/Items --insecure | python -mjson.tool

        /// <summary>
        /// Gets a list of all Items.
        /// </summary>
        /// <returns>An IEnumerable of Item details.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDetails>>> Get()
        {
            return Ok(await _service.GetItems());
        }

        // GET api/values/5
        /// <summary>
        /// Get a specific item.
        /// </summary>
        /// <param name="id">The Item Id.</param>
        /// <returns>An Item.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ItemDetails>> Get(string id)
        {
            var idGuid = Guid.Parse(id);
            var item = await _service.GetItemById(idGuid);

            if (item == null)
            {
                return NotFound();
            }
           
            var images = _imageService.GetImagesByItemId(idGuid);

            item.Images = images;

            return Ok(item);
        }

        // POST api/values
        /// <summary>
        /// Creates a new Item
        /// </summary>
        /// <param name="item">The Item data</param>
        /// <param name="fileArray">An array of files</param>
        /// <returns>The created Item.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([ModelBinder(BinderType = typeof(JsonModelBinder))] ItemCreate item, List<IFormFile> fileArray)
        {
            var images = new List<Image>();
            if (fileArray.Any())
            {
                images = await _imageService.UploadImages(fileArray);
            }
            var result = await _service.CreateItem(item, images);
            if(result.Id != Guid.Empty)
            {
                return CreatedAtAction(nameof(Get), new { id = result.Id.ToString() }, result);
                //return Ok(result);
            }
            return BadRequest();
        }

        // PUT api/values/5

        /// <summary>
        /// Updates a cerain Item
        /// </summary>
        /// <param name="id">The item Id</param>
        /// <param name="item">The Item</param>
        /// <param name="fileArray">The Files</param>
        /// <returns>The updated item.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(string id, [ModelBinder(BinderType = typeof(JsonModelBinder))] ItemEdit item, List<IFormFile> fileArray)
        {
            Guid _id;
            var idGuid = Guid.TryParse(id, out _id);
            var images = new List<Image>();

            if (idGuid && item != null)
            {
                // Check if the request contains multipart/form-data.
                if (fileArray.Any())
                {
                    // we have files...
                    images = await _imageService.UploadImages(fileArray);
                }
                
                var result = await _service.UpdateItemById(_id, item, images);
                if (result != null)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest("Invalid Data");
                }
            }

            return BadRequest("Empty Item record passed down doofus!");
        }

        // DELETE api/values/5

        /// <summary>
        /// Deletes an Item
        /// </summary>
        /// <param name="id">The Id of the Item</param>
        /// <returns>200 If Sucessful</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                Guid itemId;
                Guid.TryParse(id, out itemId);
                var result = await _service.DeleteItemById(itemId);
                if(result){
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
